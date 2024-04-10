## P2 - Déboguer une application .NET - Site E-commerce Lambazon

### Bugs recensés : 


FAIT : 

- Le choix des langues est "Francais, Anglais, Espagnol". L'espagnol n'est pas disponible dans les ressources. Je passe l'espagnol en commentaire, et signalerait la nécéssité d'implementer des fichiers langage en espagnol pour le rendre disponible.

- Il ne se passe rien lorsque l'on clique sur "Ajouter au panier" : pas de changement de page vers le panier, ni d'ajout au panier (vérification en allant sur la page du panier). Pas de décrémentation du stock non plus. --->> aprés l'ajout de la méthode "AddItem" dans la classe Cart.cs, le produit semble s'ajouter, mais rien ne s'affiche sur le panier. --->> le probleme venait de la méthode GetCartLineList() qui créait un nouvel objet CartLine à chaque fois. J'ai externalisé la création de l'objet, ainsi GetCartLineList() ne sert qu'à récupérer l'état actuel de l'objet --->> Les produits s'affichent bien dans le panier, mais à chaque ajout d'un exemplaire d'un produit, cela rajoute une ligne supplémentaire au panier, au lieu de les incrémenter sur une seule ligne. --->> Probleme réglé en utilisant une comparaison de l'id du produit actuel avec les produits présents dans le panier.

- Le total et la moyenne ne sont pas calculés. --->>> c'est ok

- Le changement de langue, lorsque l'on sélectionne la langue dans le menu déroulant en bas à droite, ne fonctionne pas (par défaut la langue reste sur fr-FR).

- Sur la page du panier, on peut accéder au formulaire de passage de commande alors que le panier est vide. --->>> verification ajoutée dans OrderController

- Le champ "Code postal" doit avoir une valeur numérique et non du texte. Il n'est pas en "required". --->>> Modifier les regles de validation dans Order.cs

- Le stock de produit ne se met pas à jour au moment de la commande --->>> probablement un souci au niveau du changement du type de la liste product qui était jusque là un Array et qu'on a transformé en list 
--->> c'est le cas avec le test Product dont le type en assert n'etait plus le bon.
--->> Le test pour UpdateProductQuantities() ne fonctionnait pas dans sa deuxieme partie car il réinitialisait le productRepository
--->> Lorsque je passe une commande, le message affiché est "La démo est terminée, cliquez sur le logo pour recommencer." - Je ne peux donc pas voir si le stock est mis à jour via le front, si le fait de retourner a la liste des produits remet tout à 0. Je vais vérifier la mise à jour des infos via le debugger.  --->>> ajout d'une routine dans le product repository pour ne générer une nouvelle liste de produit qu'une seule fois au démarrage de l'appli

A FAIRE : 

- Les messages d'erreurs sur les champs requis ne s'affichent pas ? (à vérifier avec un autre navigateur) --->>> probleme d'affichage des messages d'erreurs avec JS, les messages s'affichent dés que JS est desactivé. --->>> il manque les fichiers de traduction pour les messages d'erreur, ou les liens vers eux

IDE pour du .NET : 

- Visual Studio, l'ide Natif de microsoft, IDE puissant et complet pour le développement C# et .NET. Fonctionnalités intégrés : IntelliSense, Deboggage, tests unitaires, etc... ; Intégration facile avec les outils microsoft (Azure Devops, etc...) et l'environnement microsoft.

- Visual Studio Code : L'éditeur de code ++ de microsoft léger et rapide, tres modulable et polyvalent, mais beaucoup moins puissant que Visual Studio. Gratuit et opensource. Peu d'outils de collaborations nativement.

- Rider, par Jetbrains : puissant et efficace, spécialisé en c# .NET, propose de nombreux outils intégrés, mais cher et non-microsoft.

Git : 

- GitHub : le plus connu, la plus grande communauté, lié à Github copilot, efficace et puissant. Propose des outils tels que les Issues et les pull requests. A voir en terme de tarifs pour une utilisation pro.

- Gitlab : créé de la cission d'une partie de la communauté Github apres le rachat par microsoft. Tres orienté "open source". Tres bien aussi, propose des fonctionnaltiés telles que l'intégration continue et la livraison continue.

- BitBucket : Le systeme de git propriétaire d'Atlassian, lié notamment à des outils de gestion tels que Jira et Confluence. Tres bien si on travaille déjà dans l'environnement Atlassian. Les fonctionnalités sont vite tarifées.

Deux facteurs à prendre en comtpe quand on choisi les outils pour un projet : 

- Le tarif : faut-il utiliser des outils gratuits open-source ou plutot des outils payants ? Si oui, est-ce que le tarif est adapté au budget de l'entreprise et du projet ?

- La communauté : Un outil qui possede une grande communauté active permettra plus facile d'obtenir des reponses en cas de souci, et peut-être potentiellement mieux suivi.

- Les fonctionnaltiés : Un bon outil doit être choisir pour les outils qu'ils propose à l'aide à sa tache principale. Son ergonomie et sa stabilité sont aussi des arguments importants.



