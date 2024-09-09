# API Spell

## Résumé du Projet

API Spell est un système innovant destiné aux Maîtres de Jeu (MJs) et joueurs de jeux de rôle sur table, permettant la génération et la gestion de sorts personnalisés. Grâce à l'intégration d'OpenAI, cette API facilite la création de sorts uniques et la gestion d'une banque de sorts personnelle.

## Objectifs

- **Génération de Sorts** : Créez des sorts uniques en utilisant l'IA.
- **Système d'AddOns** : Personnalisez et améliorez les sorts avec des modificateurs.
- **Gestion des Comptes Utilisateurs** : Gérez les comptes et les sorts personnels. Offrir aux joueurs un acces à leur grimoire.
- **Banque de Sorts** : Stockez et organisez les sorts créés.

## Fonctionnalités

- **Création et modification de Sorts** : Endpoints pour définir les paramètres des sorts. Ou les modifier.
- **Équilibrage** : Assurez-vous que les sorts sont équilibrés pour le jeu.
- **Gestion des Interactions** : Gérez les interactions entre différents AddOns.

## Architecture Technique

- **API RESTful** : Interface principale pour interagir avec le système.
- **Intégration OpenAI** : Utilisation des modèles d'IA pour la génération de contenu.
- **Base de Données** : Stockage des informations utilisateurs et des sorts.
- **Système d'Authentification** : Gestion sécurisée des accès utilisateurs.

## Modèle de Données

- **Utilisateurs** : Informations de compte, préférences, rôles (MJ/Joueur).
- **Sorts** : Nom, description, coût en mana, effets de base.
- **AddOns** : Modificateurs pour personnaliser les sorts.
- **Banque de Sorts** : Collection de sorts associée à chaque utilisateur.

## Aspects Techniques

- **Tests Unitaires** : Tests robustes pour assurer la fiabilité du système.
- **Gestion des Erreurs** : Mécanismes pour gérer les erreurs et fournir des retours utiles.

## Installation

1. Clonez le dépôt :
    ```bash
    git clone https://github.com/username/repository.git
    ```
2. Installez les dépendances :
    ```bash
    cd repository
    dotnet restore
    ```
3. Configurez les variables d'environnement (voir `appsettings.json` pour plus de détails).

4. Lancez l'application :
    ```bash
    dotnet run
    ```

## Utilisation

**Pour le moment l'application n'est pas encore en ligne. Vous pouvez cloner le projet et le lancer pour tester l'application avec swagger.** 

## Documentation

Pour plus de détails sur les API et les endpoints, veuillez consulter [à implemeter].


