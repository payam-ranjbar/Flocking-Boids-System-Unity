# Flocking Boids System with Custom Paths in Unity

This Unity project implements a boids flocking system combined with a custom Bezier path System. It uses a CPU-based docking algorithm to guide boids to dock or align with designated positions along a precomputed path.


<video width="640" height="360" controls>

  <source src="https://github.com/payam-ranjbar/Flocking-Boids-System-Unity/blob/main/Demo.mp4" type="video/mp4">

  Your browser does not support the video tag.

</video>

## Features
<video width="640" height="360" controls>
- **Flocking Boids**
  - Simulates natural flocking behavior using individual boid agents.
  - Implements steering, avoidance, alignment, and cohesion rules.
  - Uses a CPU-based docking algorithm to smoothly guide boids towards designated docking positions along a preset path.

- **Custom Bezier Path System**
  - Generates smooth paths using waypoints with adjustable tangent offsets.
  - Bakes Bezier curves into nodes for guiding boid movement.
  - Provides visual tools for path editing directly within the Unity Editor.

- **Editor Tools & Utilities**
  - **PathEditor & WaypointEditor**: Custom editors for modifying paths and waypoint tangents in the scene.
  - **ProbablityExtentions**: Helper methods for randomization and probability-based decisions.
  - **SkyBoxShaderManager**: Dynamically updates skybox shader properties based on scene lighting.

## Project Structure

- **Navigation Folder**
  - **Path.cs**: Defines and bakes Bezier paths using waypoints.
  - **PathTraverser.cs**: Moves GameObjects along the baked Bezier path (guiding boid movement).
  - **Waypoint.cs**: Represents individual waypoints with tangent offsets for Bezier curves.

- **Editor Tools**
  - **PathEditor.cs**: Custom inspector for the path component with extra functionalities.
  - **WaypointEditor.cs**: Enables in-scene editing for waypoint tangents.
  - **PathEditorView.cs**: Base for further custom editor visualization features.

- **Flocking System**
  - **Flock.cs**: Implements boid behavior including movement, steering, and docking based on CPU calculations.
  - **FlockManager.cs**: Manages global flock settings, boid instantiation, and overall simulation parameters.

- **Utilities**
  - **ProbablityExtentions.cs**: Offers helper functions for randomness and probability calculations.
  - **SkyBoxShaderManager.cs**: Updates skybox shaders dynamically based on the directional light's orientation.

## Setup and Usage

1. **Import the Project**  
   Clone or download the repository and open the project in Unity via Unity Hub.

2. **Scene Setup**
   - **Flocking System**:  
     - Place the `FlockManager` GameObject in your scene.
     - Assign a boid prefab (with the `Flock` script attached) to the FlockManager.
     - Adjust flocking parameters (e.g., speed, neighbor distance, avoidance threshold) in the inspector.
   - **Bezier Path System**:  
     - Create a new GameObject with the `Path` component.
     - Add child GameObjects with the `Waypoint` component to define your path.
     - Use the custom editors (PathEditor and WaypointEditor) for precise editing of waypoint positions and tangents.
   - **Docking Algorithm**:  
     - The CPU-based docking algorithm ensures that boids can dock to predefined positions along the baked path when required.

3. **Running the Simulation**  
   Press **Play** in the Unity Editor to see:
   - Boids exhibiting flocking behavior and docking along the path.
   - Movement guided by the precomputed Bezier path without runtime control over trajectory adjustments.

## Customization

- **Flocking Behavior**:  
  Tweak parameters in `FlockManager` and `Flock` scripts to modify speed, avoidance, and alignment for varied flocking dynamics.

- **Path Editing**:  
  Adjust the Bezier step size, waypoint positions, and tangent offsets in the `Path` and `Waypoint` components to change path curvature and smoothness.

- **Docking Algorithm**:  
  Modify the CPU-based docking logic in the `Flock` script if additional docking behaviors or performance optimizations are needed.

- **Shader Management**:  
  Customize skybox lighting by updating the `SkyBoxShaderManager` component to suit your scene’s visual style.



## Acknowledgments

- The CPU-based docking and flocking behaviors were inspired by [Holistic3D's Boids Tutorial](https://www.youtube.com/watch?v=eMpI1eCsIyM&t=38s).
