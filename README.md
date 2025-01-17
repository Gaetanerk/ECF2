# ECF2 Application

## Description

ECF2 est une application bas�e sur ASP.NET Core et Blazor qui permet de g�rer des �v�nements et les participants. 
L'application utilise une base de donn�es SQL pour stocker les informations des �v�nements et des utilisateurs, 
et une base de donn�es NoSQL (MongoDB) pour stocker les statistiques des participants.

## Pr�requis

- .NET 8
- SQL Server (localdb)
- MongoDB

## Configuration

### Configuration de la base de donn�es SQL

La cha�ne de connexion pour la base de donn�es SQL est configur�e dans le fichier `appsettings.json` :

### Configuration de MongoDB

La cha�ne de connexion pour MongoDB est �galement configur�e dans le fichier `appsettings.json` :

## Installation

1. Clonez le d�p�t :

https://github.com/Gaetanerk/ECF2.git

2. Installez les d�pendances :

dotnet restore

3. Mettez � jour la base de donn�es :

dotnet ef database update

4. Lancez l'application :

dotnet run

## Routes

### �v�nements

- **GET /Events** : Affiche la liste des �v�nements.
- **GET /Events/Details/{id}** : Affiche les d�tails d'un �v�nement sp�cifique.
- **GET /Events/Create** : Affiche le formulaire de cr�ation d'un nouvel �v�nement.
- **POST /Events/Create** : Cr�e un nouvel �v�nement.
- **GET /Events/Edit/{id}** : Affiche le formulaire d'�dition d'un �v�nement existant.
- **POST /Events/Edit/{id}** : Met � jour un �v�nement existant.
- **GET /Events/Delete/{id}** : Affiche la confirmation de suppression d'un �v�nement.
- **POST /Events/Delete/{id}** : Supprime un �v�nement existant.
- **GET /Events/Participate/{eventId}** : Affiche le formulaire pour participer � un �v�nement.
- **POST /Events/Participate** : Enregistre un utilisateur comme participant � un �v�nement.
- **GET /Events/Statistics** : Affiche les statistiques des participants pour chaque �v�nement.

### Utilisateurs

- **GET /Users** : Affiche la liste des utilisateurs.
- **GET /Users/Details/{id}** : Affiche les d�tails d'un utilisateur sp�cifique.
- **GET /Users/Create** : Affiche le formulaire de cr�ation d'un nouvel utilisateur.
- **POST /Users/Create** : Cr�e un nouvel utilisateur.
- **GET /Users/Edit/{id}** : Affiche le formulaire d'�dition d'un utilisateur existant.
- **POST /Users/Edit/{id}** : Met � jour un utilisateur existant.
- **GET /Users/Delete/{id}** : Affiche la confirmation de suppression d'un utilisateur.
- **POST /Users/Delete/{id}** : Supprime un utilisateur existant.

## Mod�les

### Event

### User

### UserEvent

### EventParticipant (MongoDB)

### EventStatisticsViewModel

## Utilisation

Cr�er votre utilisateur pour pouvoir participer � un �v�nement.

Vous pouvez modifier et supprimer des utilisateurs.

Vous pouvez cr�er, modifier et supprimer des �v�nements sans avoir besoin de cr�er un utilisateur.

Vous pouvez voir le nombre de participants pour chaque �v�nement.

## Lien GitHub

[ECF2 sur GitHub](https://github.com/Gaetanerk/ECF2.git)