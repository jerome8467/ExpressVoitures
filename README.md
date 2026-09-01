# Express Voitures

Application web ASP.NET Core MVC développée dans le cadre du Projet 5 de la formation Back-End .NET d'OpenClassrooms.

## Description

Application de gestion pour un revendeur de voitures d'occasion. Elle permet de gérer le catalogue de véhicules, les réparations, les transactions et les images.

## Fonctionnalités

### Public
- Consultation du catalogue de véhicules disponibles à la vente
- Visualisation du détail d'un véhicule avec ses photos

### Administrateur
- Authentification sécurisée
- Dashboard avec statistiques (coût moyen des réparations, revenus, délai moyen de vente...)
- Gestion complète des véhicules (ajout, modification, suppression)
- Gestion des constructeurs, modèles et finitions
- Gestion des images (upload, suppression, définition de la photo de couverture)

## Technologies

- **Back-end** : ASP.NET Core MVC .NET 8, Entity Framework Core, Identity
- **Base de données** : SQL Server
- **Front-end** : Razor Views, JavaScript, Bootstrap, Flatpickr, TomSelect, Dropzone.js
- **Tests** : xUnit, Moq, SQLite (tests d'intégration)

## Installation

### Prérequis
- .NET 8 SDK
- SQL Server

### Configuration
1. Clonez le repository
2. Modifiez la chaîne de connexion dans `appsettings.json`
3. Appliquez les migrations
4. Lancez l'application

### Compte administrateur par défaut
- **Email** : admin@expressvoitures.fr
- **Mot de passe** : Password123!

## Auteur
Jérôme Jaegle — Formation OpenClassrooms Back-End .NET
