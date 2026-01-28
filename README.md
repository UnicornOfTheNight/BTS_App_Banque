# 🏦 BTS App Banque

![Status](https://img.shields.io/badge/Status-Development-yellow)
![License](https://img.shields.io/badge/License-MIT-blue)

Une application de gestion bancaire développée dans le cadre du cursus **BTS SIO** (Services Informatiques aux Organisations). Ce projet permet la gestion des clients, des comptes bancaires et des opérations courantes via une console.

## 📋 Table des Matières

- [Fonctionnalités](#-fonctionnalités)
- [Architecture & Technologies](#-architecture--technologies)
- [Prérequis](#-prérequis)
- [Installation](#-installation)
- [Base de Données](#-base-de-données)
- [Auteurs](#-auteurs)

## 🚀 Fonctionnalités

L'application couvre les besoins essentiels d'un conseiller bancaire :

* **Gestion des Clients** : Création, modification et suppression de profils clients.
* **Gestion des Comptes** : 
    * Ouverture et clôture de comptes (Courant, Épargne).
    * Consultation du solde et de l'historique.
* **Opérations Bancaires** :
    * Crédit / Débit.
    * Virement compte à compte (interne).

## 🛠 Architecture & Technologies

Ce projet utilise les technologies suivantes :

* **Langage** : C#
* **Framework / IDE** : Visual Studio
* **Outils de versionning** : Git & GitHub

## ⚙️ Prérequis

Avant de lancer le projet, assurez-vous d'avoir installé :

1.  Visual Studio

## 💻 Installation

Pour installer et lancer le projet localement :

1.  **Cloner le dépôt :**
    ```bash
    git clone [https://github.com/UnicornOfTheNight/BTS_App_Banque.git](https://github.com/UnicornOfTheNight/BTS_App_Banque.git)
    ```
    
2.  **Lancer l'application :**
    * Ouvrez le projet avec votre IDE.
    * Compilez et exécutez (`F5` ou `Run`).

## 🗄 Base de Données

Le Modèle Logique de Données (MLD) s'articule principalement autour des tables :
* `Client`
* `Compte` (avec héritage ou type pour Courant/Epargne)
* `Operation`


## 👥 Auteurs

* **UnicornOfTheNight** - *Développement principal*

---
*Ce projet a été réalisé dans un but pédagogique pour l'examen du BTS SIO.*
