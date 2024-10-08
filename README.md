# API Spell [Work In Progress]

### Pourcentage approximatif d'avancement du projet :
![2024-09-17_16h14_30](https://github.com/user-attachments/assets/43b79801-ba85-45bc-9829-b9f4943b73dd)


## Résumé du Projet

API Spell est un système innovant destiné aux Maîtres de Jeu (MJs) et aux joueurs de jeux de rôle sur table, permettant la génération et la gestion de sorts personnalisés. Grâce à l'intégration d'OpenAI, cette API facilite la création de sorts uniques et la gestion d'une banque de sorts personnelle.

## Objectifs

- **Création de Sorts** : Créez des sorts pour le jeu de rôle **Atlantea** (création personnelle). **(90% Done)**
- **Génération de Sorts** : Générez des sorts via un LLM (OpenAI, Mistral, etc.). **(0% Done)**
- **Gestion des Comptes Utilisateurs** : Gérez les comptes et les sorts personnels. Offrez aux joueurs un accès à leur grimoire. **(30% Done)**
- ~~**Banque de Sorts** : Stockez et organisez les sorts créés.~~ **(100% Done)**

## Fonctionnalités

- **Création et Modification de Sorts** : Endpoints pour définir les paramètres des sorts ou les modifier.
- **Équilibrage** : S'assurer que les sorts sont équilibrés pour le jeu.
- **Gestion des Interactions** : Gérez différents utilisateurs de l'API, les MJs et les joueurs.

## Architecture Technique

- **API RESTful** : Interface principale pour interagir avec le système.
- **Intégration OpenAI** : Utilisation des modèles d'IA pour la génération de contenu.
- **Base de Données** : Stockage des informations utilisateurs et des sorts.
- **Système d'Authentification** : Gestion sécurisée des accès utilisateurs.

## Modèle de Données

- **Utilisateurs** : Informations de compte, préférences, rôles (MJ/Joueur).
- **Sorts** : Nom, description, coût en mana, effets de base.
- **AddOns** : Modificateurs pour personnaliser les sorts.
- **Grimoire** : Collection de sorts associée à chaque utilisateur.

## Aspects Techniques

- **Tests Unitaires** : Tests robustes pour assurer la fiabilité du système.
- **Gestion des Erreurs** : Mécanismes pour gérer les erreurs et fournir des retours utiles.

## Installation

1. Clonez le dépôt :
    ```bash
    git clone https://github.com/Tyralf/SpellGeneratorAPI.git
    ```
2. Installez les dépendances :
    ```bash
    cd [votre repository local]
    dotnet restore
    ```
3. Configurez les variables d'environnement (voir `appsettings.json` pour plus de détails).

4. Lancez l'application :
    ```bash
    dotnet run
    ```

## Utilisation

**Pour le moment, l'application n'est pas encore en ligne. Vous pouvez cloner le projet et le lancer pour tester l'application avec Swagger.**
