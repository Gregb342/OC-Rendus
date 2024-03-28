using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> cartLines = new List<CartLine>();
        private List<CartLine> GetCartLineList()
        {
            return cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method
            CartLine newCartLine = new CartLine();
            newCartLine.Product = product;
            newCartLine.Quantity = quantity;
            newCartLine.OrderLineId = GetCartLineList().Count + 1;

            List<CartLine> cartLines = GetCartLineList();
            cartLines.Add(newCartLine);

            System.Diagnostics.Debug.WriteLine("boubou : {newCartLine.Product.Name} ");

        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
/*        GRB : J'ai remplacé cette écriture par une version "entre accolades" 
 *        pour me faciliter la lecture du code.
 *        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);*/
        public void RemoveLine(Product product)
        {
            GetCartLineList().RemoveAll(delegate (CartLine l)
            {
                return l.Product.Id == product.Id;
            });
        }


        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary> 
        public double GetAverageValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            return null;
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
