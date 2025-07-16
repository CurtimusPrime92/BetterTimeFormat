# Copilot Instructions for BetterTimeFormat RimWorld Mod

## Mod Overview and Purpose
BetterTimeFormat is a RimWorld mod designed to enhance the game's interface by improving the time and date display formats. This mod provides an intuitive and customizable way for players to view in-game time, adapting to different players' preferences and enhancing their gaming experience.

## Key Features and Systems
- **Customizable Date and Time Display**: Allows players to choose their preferred date and time formats via mod settings.
- **Seamless XML Integration**: Utilizes the game's XML structure for easy configuration and compatibility.
- **Harmony Patching**: Uses Harmony library to apply non-invasive patches, ensuring compatibility with other mods and the base game.
- **User Settings Management**: Stores user preferences persistently using the built-in ModSettings system.

## Coding Patterns and Conventions
- **Naming Conventions**: Classes and methods follow PascalCase. Private variables use camelCase prefixed with an underscore.
- **Methods**: Each method should be focused on a single responsibility, keeping them concise and modular.
- **Documentation**: Use XML comments (`///`) to document public classes and methods, providing clear descriptions of functionality.

## XML Integration
- **Structure**: XML files are leveraged for configuration and localization, ensuring that modifications are easily accessible and editable.
- **Custom Tags**: Extend the game's XML capabilities to include custom tags for time and date formats, allowing for straightforward customization.
- **Localization Support**: Provide support for multiple languages by defining string resources in separate XML files.

## Harmony Patching
- **Setup**: Use Harmony to create patches for the base game's methods that handle date and time displays.
- **Prefix and Postfix**: Implement both prefix and postfix patches where necessary to modify behavior without directly altering base game files.
- **Conflict Management**: Ensure patches are written with compatibility in mind, using Harmony's precautionary checks to prevent conflicts with other mods.

## Suggestions for Copilot
- **Code Completion**: Use Copilot to automate boilerplate code, such as property getters/setters and simple method stubs.
- **XML Handling**: Generate XML snippets for configuration files to streamline the integration of custom settings.
- **Harmony Patching Templates**: Suggest common patterns for Harmony prefix and postfix patches to speed up the mod development process.
- **Consistent Formatting**: Ensure code suggestions adhere to established coding patterns and conventions for consistency.
- **Documentation Assistance**: Provide support for generating XML code comments, enhancing readability and maintainability of the code.

By following these guidelines and leveraging the features of GitHub Copilot, mod developers can efficiently develop and maintain the BetterTimeFormat mod for RimWorld, ensuring a smooth and enhanced gaming experience for users.
