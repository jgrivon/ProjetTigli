## Rapport Projet Web Service

Cette archive elhaouari.zip ou grivon.zip contient 2 répertoires : 

* WCFService1.0 qui contient la bibliothèque WCF que nous avons nommé VelibLibrairy. 
* Client qui contient la solution ServiceClient. Cette solution est un client utilisant le service VelibLibrairy. 

1 endpoint est disponible avec un basicHttpBinding.

Avant de pouvoir lancer le service, vous avez besoin de lancer la commande suivante en tant qu'administrateur : 

netsh http add urlacl url=http://+:8787/ServiceVelib user=%USERNAME%


# Mise en place

Les dépendances dans les dossiers packages ont été supprimé pour ne pas alourdir le fichier. Il vous faut donc lancer visual studio pour retélécharger les dépendances du projet. 

# Programme
La bibliothèque fournie au client une méthode, qui retourne la liste d'instrucion pour suivre un chemin jusqu'à la destination en passant par une station de vélib ayant un vélo disponible. Le reste du trajet comprend que le trajet est en vélo et non pas à pied.
Le trajet est comme suit : 
- Adresse de départ. 
- Station la plus proche avec vélo disponible
-Adresse d'arrivé.


Le prix de ce Webservice est calculé sur la base des prix des API utilisées:
Paris Vélib étant gratuit on comptabilise les prix de Google Map Directions ainsi que Google Map Distance Matrix. Les deux servicent coutent 0.5 USD pour 1000 requêtes. 

Le Webservice consomme au maximum 10 requettes avant de trouver la station la plus proche sur un rayon de 2 km. 
Ensuite 2 requetes pour obtenir les chemins respectif des trajet à pied et en vélo.  
Le coup total pour une requete est de 0.006 euros pour une requete. 




