using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Cap3.Lab01.Models
{
    public class CheckoutViewModel
    {
        public Cliente Clientes { get; set; }
        public Fornecedor Fornecedores { get; set; }
        public Carrinho Compras { get; set; }
        public Pagamento MetodoPagamento { get; set; }

    }
}