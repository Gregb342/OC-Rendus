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

        /* GRB : Je crée une nouvelle méthode pour verifier les doublons
         * dans la liste actuelle du panier, et les rassembler en une seule
         * ligne */
/*        public bool checkExistantItem(Product product, CartLine cartLine)
        {
            if (product.Id == cartLine.Product.Id) 
            {
                cartLine.Quantity += 1;
                return true;
            }
            return false;
        }
*/
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
            // DONE implement the method
            double totalValue = 0;
            GetCartLineList();
            foreach (CartLine line in cartLines)
            {
                totalValue = line.Product.Price + totalValue;
            }
            return totalValue;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary> 
        public double GetAverageValue()
        {
            // DONE implement the method
            int totalQuantiy = 0;
            GetCartLineList();
            foreach (CartLine line in cartLines)
            {
                totalQuantiy = line.Quantity + totalQuantiy;
            }

            double averageValue = 0;

            averageValue = GetTotalValue() / totalQuantiy;
            return averageValue;
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
