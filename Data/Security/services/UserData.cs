using Data.Security.Interfaces;
using Entity.Context;
using Entity.Dto.Security;
using Entity.Dto.Utilities;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;


namespace Data.Security.Implementation
{
    public class UserData : IUserData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public UserData(AplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }


        public async Task<Users> GetById(int id)
        {
            var sql = @"SELECT * FROM Users WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Users>(sql, new { Id = id });
        }

        public async Task<Users> GetUserAsync(string username, string password)
        {
            var user = await context.Users
                .Where(u => u.username == username && u.password == password)
                .Select(u => new Users
                {
                    username = u.username,
                    Id = u.Id,
                    state = u.state,
                    PersonId = u.PersonId
                })
                .FirstOrDefaultAsync();

            return user;
        }


        public async Task<Users> Save(Users entity)
        {
            entity.state = true; 
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Users entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task SendPasswordResetLink(string email)
        {
            var person = await context.Person.FirstOrDefaultAsync(p => p.email == email);
            var personId = person.Id; 

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == personId);

            if (person == null)
            {
                throw new Exception("Email not found");
            }


            var token = Guid.NewGuid().ToString();

            user.ResetPasswordToken = token;
            user.ResetPasswordTokenExpiration = DateTime.UtcNow.AddHours(1);

            var resetLink = $"https://yourapp.com/reset-password?token={token}";
            SendEmail(person.email, "Password Reset", $"Click here to reset your password: {resetLink}");

        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.yourserver.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("your-email", "your-password"),
                EnableSsl = true,
            };

            smtpClient.Send("your-email", toEmail, subject, body);
        }

        public async Task ResetPassword(string token, string newPassword)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.ResetPasswordToken == token);

            if (user == null || user.ResetPasswordTokenExpiration < DateTime.UtcNow)
            {
                throw new Exception("Invalid or expired token");
            }

            // Aquí debes encriptar la nueva contraseña antes de guardarla
            user.password = (newPassword);
            user.ResetPasswordToken = null; // Eliminar el token después de usarlo
            user.ResetPasswordTokenExpiration = null;

            await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Users>> GetAll()
        {
            return await context.Users.Where(p => p.state == true).ToListAsync();
        }
        public async Task<List<Role>> GetRolesForUser(int userId)
        {
            return await context.UserRole
         .Where(ur => ur.UserId == userId)
        .Include(ur => ur.Role)
            .ThenInclude(r => r.RoleViews)
                .ThenInclude(rv => rv.View)
                    .ThenInclude(v => v.Modulo)
        .Select(ur => ur.Role)
        .ToListAsync();

        }

        public async Task<IEnumerable<UserPersonNameDto>> GetDataTable()
        {
            return await context.Users.Join(context.Person,
                user => user.PersonId,
                person => person.Id,
                (users, person) => new UserPersonNameDto
                {
                    Id = users.Id,
                    UserName = users.username,
                    PersonName = person.first_name + " " + person.last_name,
                    PersonEmail = person.email

                }).ToListAsync();
        }
    }
}
