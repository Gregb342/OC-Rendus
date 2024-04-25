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
        private List<CartLine> cartLines = new List<CartLine>();

        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns>List</returns>
        private List<CartLine> GetCartLineList()
        {
            return cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO : DONE implement the method

            if (quantity <= 0)
                {
                    throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
                }

                // GRB : On récupere le panier actuel, qui a été intialisé avec la classe.
                List<CartLine> currentCartLines = GetCartLineList();

                /* GRB : On utilise la méthode "FindProductInCartLines()" pour comparer
                 * l'ID du produit ajouté avec les ID des produits déjà existant, ce qui
                 * retourne l'objet de type Produit déjà existant dans le panier. */
                Product lineProduct = FindProductInCartLines(product.Id);

                if (lineProduct != null)
                {
                    /* GRB : On cherche la ligne correspondante du panier
                    * en utilisant la méthode "FirstOrDefault" de LINQ */
                    CartLine existingLine = cartLines.FirstOrDefault(line => line.Product.Id == product.Id);
                    existingLine.Quantity += quantity;
                }
                else
                {
                    /* GRB : Si le lineProduct est nul, cela veut dire que le produit n'existe
                     * pas encore dans le panier, on peut donc créer une nouvelle
                     * ligne avec les informations necessaires */
                    CartLine newCartLine = new CartLine();
                    newCartLine.Product = product;
                    newCartLine.Quantity = quantity;
                    newCartLine.OrderLineId = currentCartLines.Count + 1;
                    cartLines.Add(newCartLine);
                }
                                  
        }


        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
                    GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);


        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO : DONE implement the method
            double totalValue = 0;
            GetCartLineList();
            foreach (CartLine line in cartLines)
            {
                totalValue = (line.Product.Price*line.Quantity) + totalValue;
            }

            if (totalValue > 0)
            {
                return totalValue;
            }

            return 0;
        }



        /// <summary>
        /// Get average value of a cart
        /// </summary> 
        public double GetAverageValue()
        {
            // TODO : DONE implement the method
            int totalQuantiy = 0;

            double averageValue = 0;

            foreach (CartLine line in cartLines)
            {
                totalQuantiy = line.Quantity + totalQuantiy;
            }

            averageValue = GetTotalValue() / totalQuantiy;

            if (averageValue > 0)
            {
                return averageValue;
            }

            return 0;
            
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO : DONE implement the method
            foreach (CartLine line in cartLines)
            {
                if (productId == line.Product.Id)
                {
                    return line.Product;
                }
            }
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
