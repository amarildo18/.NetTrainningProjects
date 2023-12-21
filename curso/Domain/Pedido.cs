using System;
using System.Collections.Generic;
using cursoEFCore.ValueObjects;

namespace cursoEFCore.Domain
{
    public class Pedido{

        public int Id{ get; set; }
        public int clienteId{ get; set;}
        public Cliente Cliente{ get; set;}
        public DateTime IniciadoEm{ get; set; }
        public DateTime FinalizadoEm{ get; set; }
        public TipoFrete TipoFrete{ get; set; }
        public StatusPedido Status{ get; set; }
        public string Observacao{ get; set; }
        public ICollection<PedidoItem> Itens{ get; set; }
    }
}