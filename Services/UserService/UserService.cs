namespace MovieCollectionAPI.Services.UserService
{
    public class UserService
    {
    }
}


namespace MovieCollectionAPI.Services.UserMoviesService
{
    public class UserService : IUserMoviesService
    {

        private readonly DataContext context;

        public UserService(DataContext context)
        {
            this.context = context;
        }


        public async Task<List<User>> AddUser(User user)
        {
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return await this.context.Users.ToListAsync();
        }

        public async Task<List<User>?> DeleteUser(int id)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)

                return null;

            this.context.Users.Remove(user);
            await this.context.SaveChangesAsync();

            return await this.context.Users.ToListAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await this.context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetSingleUser(int id)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)

                return null;

            return user;
        }

        public async Task<List<User>?> UpdateUser(int id, User request)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)

                return null;

            user.Username = request.Username;
            user.PasswordHash = request.PasswordHash;

            await this.context.SaveChangesAsync();

            return await this.context.Users.ToListAsync();
        }
    }

    public interface IUserMoviesService
    {
    }
}
