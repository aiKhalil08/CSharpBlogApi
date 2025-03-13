using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface IJwtService
    {
        /// <summary>
        /// Generates jwt token
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Object of Comment</returns>
        string GenerateToken(string userId, string userRole);
    }
}
