## P2 - Déboguer une application .NET - Site E-commerce Lambazon

### Bugs recensés : 

- Le changement de langue, lorsque l'on sélectionne la langue dans le menu déroulant en bas à droite, ne fonctionne pas (par défaut la langue reste sur fr-FR).

- Il ne se passe rien lorsque l'on clique sur "Ajouter au panier" : pas de changement de page vers le panier, ni d'ajout au panier (vérification en allant sur la page du panier). Pas de décrémentation du stock non plus. --->> aprés l'ajout de la méthode "AddItem" dans la classe Cart.cs, le produit semble s'ajouter, mais rien ne s'affiche sur le panier. --->> le probleme venait de la méthode GetCartLineList() qui créait un nouvel objet CartLine à chaque fois. J'ai externalisé la création de l'objet, ainsi GetCartLineList() ne sert qu'à récupérer l'état actuel de l'objet --->> Les produits s'affichent bien dans le panier, mais à chaque ajout d'un exemplaire d'un produit, cela rajoute une ligne supplémentaire au panier, au lieu de les incrémenter sur une seule ligne.

- Le total et la moyenne ne sont pas calculés.

- Sur la page du panier, on peut accéder au formulaire de passage de commande alors que le panier est vide.

- Les messages d'erreurs sur les champs requis ne s'affichent pas ? (à vérifier avec un autre navigateur)

- Le champ "Code postal" doit avoir une valeur numérique et non du texte. Il n'est pas en "required".
