# 📦 Order Processing Application

**Date**: June 19, 2025  
**Author**: [Your Name]

---

## 📝 Overview

This application automates the handling of customer orders for a company that previously used a mix of manual and inconsistent methods. It applies a clear set of business rules to process each order reliably.

---

## 📚 Business Rules Handled

The system handles different types of products and applies rules accordingly:

- 📦 **Physical Product**: Generate a packing slip for shipping.
- 📕 **Book**: Generate a **duplicate** packing slip for the royalty department.
- 💳 **Membership**: Activate the membership.
- 🔼 **Membership Upgrade**: Apply the upgrade.
- 📧 **Membership Notification**: Send an email when a membership is activated or upgraded.
- 🎥 **Video - "Learning to Ski"**: Include a **free "First Aid" video** in the packing slip.
- 💰 **Agent Commission**: Generate a commission payment for the agent (for books and physical products).

---

## 🛠 Design Principles Used

This project is built using **SOLID principles** and common design patterns to make the code easy to extend and maintain.

### ✅ SOLID Principles

- **Single Responsibility Principle (SRP)**: Each rule class has one clear job.
- **Open/Closed Principle (OCP)**: You can add new rules without changing existing code.
- **Liskov Substitution Principle (LSP)**: All rule classes implement the same interface and can be used interchangeably.
- **Interface Segregation Principle (ISP)**: The `IOrderRule` interface has just one method: `Apply(Order order)`.
- **Dependency Inversion Principle (DIP)**: Classes depend on interfaces, not on specific implementations.

### 🔁 Design Patterns

- **Strategy Pattern**: Each rule represents a different strategy for processing part of the order.
- **Dependency Injection (DI)**: Services like email notification are injected into rule classes.

---

## ⚙️ How It Works

1. An `Order` object is created with products and customer information.
2. The `RuleEngine` is configured by adding all rule instances.
3. `RuleEngine.Process(order)` is called.
4. Each rule runs and performs its task (e.g., generate slip, send email, add product, etc.).

---

## ➕ Adding a New Rule

To add a new rule:

1. Create a class that implements the `IOrderRule` interface.
2. Add your logic in the `Apply(Order order)` method.
3. Register the rule in the rule engine like this:

Building and Running the Application
Prerequisites
.NET SDK 7.0 or higher
Visual Studio 2022 or Visual Studio Code
