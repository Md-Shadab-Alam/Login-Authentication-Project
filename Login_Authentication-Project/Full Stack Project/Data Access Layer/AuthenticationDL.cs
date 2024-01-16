using Full_Stack_Project.Models;
using System.Security.Cryptography.X509Certificates;

namespace Full_Stack_Project.Data_Access_Layer
{
    public class AuthenticationDL
    {

        private readonly FullStackDBContext _dbContext;
        public AuthenticationDL(FullStackDBContext context)
        {
            _dbContext = context;
        }

        public RegisterUser RegisterDL(Users user)
        {
            RegisterUser reg = new RegisterUser();

            reg.IsSuccess = true;
            reg.message = "Register Successfull";


            var newUser = _dbContext.Users.FirstOrDefault(x => x.Username == user.Username || x.Email == user.Email);
            if (newUser != null)
            {
                reg.message = "User already Exist !!!";
                reg.IsSuccess = false;

                return reg;
            }

            // calling Encrypt_decrypt Class
            Encrypt_Decrypt en = new Encrypt_Decrypt();

            user.Password = en.EncryptPassword(user.Password);
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;
            

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return reg;
        }
        public LoginUserResponse LoginDL(LoginUser user)
        {
            LoginUserResponse res = new LoginUserResponse();

            res.IsSuccess = true;
            res.Message = "Login Successful";


            Encrypt_Decrypt dn = new Encrypt_Decrypt();

            var existingUser = _dbContext.Users.FirstOrDefault(x => x.Username == user.Username);
           
            if(existingUser != null) 
            {
                bool isValid = (existingUser.Username == user.Username && dn.DecryptPassword(existingUser.Password) == user.Password);

                if (isValid)
                {
                    return res;
                }
                
            }
            res.Message = "User does not exist";
            res.IsSuccess = false;
            return res;
        }

    }
}
