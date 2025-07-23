# Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose

The "Tiny Workbenches" mod for RimWorld is designed to enhance and expand the gameplay experience by introducing smaller, space-efficient versions of the standard workbenches found in the game. This mod aims to provide players with options for more compact base designs, particularly beneficial for early-game or minimalist colony setups.

## Key Features and Systems

- **Compact Workbenches**: The mod introduces a variety of new workbench items that occupy less space than their vanilla counterparts. These workbenches function identically to the originals but fit into smaller areas, allowing for more efficient base layouts.
  
- **Balanced Gameplay**: Each tiny workbench is designed to maintain balance by incorporating appropriate crafting speeds and resource costs.

- **Customization Options**: Players can configure aspects of the workbenches, such as resource costs or crafting times, via mod settings in the game UI.

## Coding Patterns and Conventions

- **Namespace and Organization**: Keep all classes under a distinct namespace related to the mod, such as `TinyWorkbenchesNamespace`, to prevent conflicts with other mods.
  
- **Class Naming**: Use clear and descriptive names for classes and methods. For example, `TinyWorkbenches.cs` should contain classes directly related to the unique functionality of the mod.

- **Commenting**: Include XML documentation comments for each class and method to provide clear guidance for future maintenance or development efforts.

- **Programming Practices**: Follow .NET best practices, including the use of properties instead of public fields, and implement proper exception handling to enhance the mod's robustness.

## XML Integration

- **Defining New Workbenches**: Use XML files to define new workbench items. These should include all necessary properties such as `ThingDefs`, `BuildingDefs`, and `RecipeDefs`.

- **Patch Existing Content**: If modifying existing vanilla objects, do this through `Defs` that extend or modify the existing definitions.

- **Localization Support**: Provide translation keys in an XML format to support multiple languages, enhancing accessibility for international players.

## Harmony Patching

- **Purpose**: Use the Harmony library to patch the game's methods to introduce or alter behaviors required by the mod without directly modifying the game code.
  
- **Implementation**: Harmony patches should be clearly labeled and documented. For instance, patches should specify the target method, the prefix/postfix to be applied, and any context that might be necessary for understanding the modification.
  
- **Cautious Use**: Only patch what is necessary to ensure compatibility with future versions of RimWorld and other mods.

## Suggestions for Copilot

- **Auto-Complete XML Tags**: Implement suggestions to automatically complete XML tags when defining new `Defs` or `KeyBindings`.

- **Generate Harmony Templates**: Assist in generating templates for Harmony patches, including common prefixes, suffixes, and transpiler hooks.

- **Code Snippet Recommendations**: Recommend snippets for common tasks such as setting up mod settings menus, integrating localization keys, or creating new ThingDefs.

- **Contextual Assistance**: Provide suggestions based on the context within `TinyWorkbenches.cs` to quickly develop methods that adhere to existing class conventions.

By following these guidelines and leveraging GitHub Copilot where possible, the development and maintenance of the "Tiny Workbenches" RimWorld mod can be streamlined for efficiency and quality.
