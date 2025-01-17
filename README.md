# ECF2 Application

## Description

ECF2 est une application basée sur ASP.NET Core et Blazor qui permet de gérer des événements et les participants. 
L'application utilise une base de données SQL pour stocker les informations des événements et des utilisateurs, 
et une base de données NoSQL (MongoDB) pour stocker les statistiques des participants.

## Prérequis

- .NET 8
- SQL Server (localdb)
- MongoDB

## Configuration

### Configuration de la base de données SQL

La chaîne de connexion pour la base de données SQL est configurée dans le fichier `appsettings.json` :

### Configuration de MongoDB

La chaîne de connexion pour MongoDB est également configurée dans le fichier `appsettings.json` :

## Installation

1. Clonez le dépôt :

https://github.com/Gaetanerk/ECF2.git

2. Installez les dépendances :

dotnet restore

3. Mettez à jour la base de données :

dotnet ef database update

4. Lancez l'application :

dotnet run

## Routes

### Événements

- **GET /Events** : Affiche la liste des événements.
- **GET /Events/Details/{id}** : Affiche les détails d'un événement spécifique.
- **GET /Events/Create** : Affiche le formulaire de création d'un nouvel événement.
- **POST /Events/Create** : Crée un nouvel événement.
- **GET /Events/Edit/{id}** : Affiche le formulaire d'édition d'un événement existant.
- **POST /Events/Edit/{id}** : Met à jour un événement existant.
- **GET /Events/Delete/{id}** : Affiche la confirmation de suppression d'un événement.
- **POST /Events/Delete/{id}** : Supprime un événement existant.
- **GET /Events/Participate/{eventId}** : Affiche le formulaire pour participer à un événement.
- **POST /Events/Participate** : Enregistre un utilisateur comme participant à un événement.
- **GET /Events/Statistics** : Affiche les statistiques des participants pour chaque événement.

### Utilisateurs

- **GET /Users** : Affiche la liste des utilisateurs.
- **GET /Users/Details/{id}** : Affiche les détails d'un utilisateur spécifique.
- **GET /Users/Create** : Affiche le formulaire de création d'un nouvel utilisateur.
- **POST /Users/Create** : Crée un nouvel utilisateur.
- **GET /Users/Edit/{id}** : Affiche le formulaire d'édition d'un utilisateur existant.
- **POST /Users/Edit/{id}** : Met à jour un utilisateur existant.
- **GET /Users/Delete/{id}** : Affiche la confirmation de suppression d'un utilisateur.
- **POST /Users/Delete/{id}** : Supprime un utilisateur existant.

## Modèles

### Event

### User

### UserEvent

### EventParticipant (MongoDB)

### EventStatisticsViewModel

## Utilisation

Créer votre utilisateur pour pouvoir participer à un événement.

Vous pouvez modifier et supprimer des utilisateurs.

Vous pouvez créer, modifier et supprimer des événements sans avoir besoin de créer un utilisateur.

Vous pouvez voir le nombre de participants pour chaque événement.

## Lien GitHub

[ECF2 sur GitHub](https://github.com/Gaetanerk/ECF2.git)