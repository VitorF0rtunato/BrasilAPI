using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAM_BrasilAPI.Models
{
    public class Previsao
    {
        public string Cidade {  get; set; }
        public string Estado { get; set; }
        public string Atualizado_em {  get; set; }
        public Array Clima { get; set; }
    }
}
