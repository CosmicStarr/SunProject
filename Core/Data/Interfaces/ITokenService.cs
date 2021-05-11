using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser User);
    }
}
