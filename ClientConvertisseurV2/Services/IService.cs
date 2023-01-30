using ClientConvertisseurV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Services
{
    public interface Iservice
    {
        Task<List<Devise>> GetDevisesAsync(string nomControleur);
    }
}
