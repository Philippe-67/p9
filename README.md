# Projet Express Voitures

Ce projet est une application codée en C# utilisant Entity Framework Core, avec une base de données réalisée en Code First. La société Express Voiture achète des voitures aux enchères, les répare et les revend avec un bénéfice de 500€. L'application permet à tous les utilisateurs d'accéder aux informations, mais seuls l'administrateur Jacques est autorisés à effectuer des modifications.

## Fonctionnalités

- Affichage des informations sur les voitures disponibles à la vente.
- Consultation des informations sur les réparations effectuées sur chaque voiture.
- Possibilité pour l'administrateur Jacques, de modifier les informations sur les voitures et les réparations.

## Installation

1. Clonez ce référentiel sur votre machine locale.
2. Assurez-vous que vous avez C# installé.
3. Installez les dépendances en exécutant la commande suivante dans votre terminal :

dotnet restore

4. Configurez votre base de données en modifiant la chaîne de connexion dans le fichier appsettings.json.
5. Appliquez les migrations pour créer la base de données en exécutant la commande suivante :

dotnet ef database update


## Utilisation

1. Compilez et exécutez l'application en utilisant la commande suivante :

dotnet run

2. Ouvrez votre navigateur et accédez à l'URL [http://localhost:7164](http://localhost:7164) pour accéder à l'application.

## Structure du projet

- Program.cs : Le point d'entrée de l'application.
- Startup.cs : La configuration de l'application et l'injection de dépendances.
- Controllers/ : Les contrôleurs de l'application pour la gestion des routes et des actions.
- Models/ : Les modèles de données utilisés dans l'application.
- Data/ : Les classes de contexte et les migrations pour la gestion de la base de données.
- Views/ : Les vues de l'application pour l'affichage des informations.
- wwwroot/ : Les fichiers statiques tels que les feuilles de style CSS et les images.

