# Store Simulator 3D

A 3D store simulation game developed with **Unity and C#**.

The project focuses on building a complete gameplay loop, from managing inventory and displaying products to interacting with shelves and completing customer purchases.

## Demo

> Add gameplay video or GIF here.

## Features

- Complete store gameplay loop:
  **Inventory → Product Display → Customer Interaction → Sales**
- Inventory management system for storing and managing products.
- Shelf interaction system for placing and managing products.
- Customer spawning system with customers appearing over time.
- Customer navigation using **Unity NavMesh**.
- Buying and selling interactions between the player and customers.
- Basic payment and transaction flow.

## Technical Highlights

### Inventory System

Designed an inventory system to manage store products and their quantities.

The system separates product data from gameplay logic, making it easier to extend the store with additional item types.

### Customer Spawning & Navigation

Implemented a customer spawning system that creates customers over time.

Customers use **Unity NavMesh** to navigate through the store and move toward their target locations.

This allowed me to practice:

- NavMesh setup
- Agent movement
- Target-based navigation
- Runtime spawning
- Managing multiple NPCs

### Shelf Interaction

Implemented interactive shelves that allow the player to manage displayed products.

The interaction system connects the player's actions with the inventory and product management systems.

### Buying & Selling

Implemented the basic store transaction flow:

1. Customer enters the store.
2. Customer interacts with available products.
3. Product quantity is updated.
4. Transaction is processed.
5. Store inventory is updated.

## Architecture & Programming

The project was developed using **C# and object-oriented programming principles**.

I focused on separating gameplay responsibilities into independent systems instead of putting all logic into a single MonoBehaviour.

Key concepts practiced:

- Object-Oriented Programming
- Encapsulation
- Separation of responsibilities
- Modular gameplay systems
- Reusable components
- Unity component-based architecture

## What I Learned

Through this project, I practiced designing gameplay systems that interact with each other while keeping their responsibilities separated.

The project also helped me gain practical experience with:

- Unity NavMesh
- NPC spawning
- Inventory management
- Object interaction
- Gameplay loops
- C# OOP
- Debugging and iteration

## Tech Stack

- **Engine:** Unity
- **Language:** C#
- **AI / Navigation:** Unity NavMesh
- **Version Control:** Git / GitHub
