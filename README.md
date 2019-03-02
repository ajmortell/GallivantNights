# GallivantNights
A cyber-horror thriller. An homage to games like Snatcher and Super Spy-hunter.

# 
 
We have added a small tech demo that allows you to use yarn to make animated panels along with your text/options.

### To use simply..
**1.**  Open the file in Assets/Scenes called DialogueScene

**1.** Once in unity navigate to the folder structure and look in Assets/Prefabs/Animations/Scenes/...
 
 → **1.)** this is where the animated panels we have set up are located.
 
 → **1.)** note there is an **AnimatedEntity** script attached to set a name, label color, type and initial state.
 
 → **1.)** These panels are loaded through the .yarn file via commands ([YarnCommand("MyCommand")]].
 
 → **1.)** You can make any sized panel you like. This size was found to be the best for our purposes.


**3.** Next load up yarn and find the scene_0.yarn file in the Assets/Yarnspinner/Dialogues folder and see how the commands are used

**4.** Next we have the DialogueManager (Assets/Scripts/Dialogue) where most of the commands are located.

**5.** Note how everything is hooked up to the Dialogue object in the hierarchy.

**6.** Don't forget that each NPC scenes needs to be noted as an NPC in the AnimatedEntity script in the inspector.
 
 → **A)** This can be changed in code but it needs and initial setting.
 

**7.** Also remember that each NPC has states that must be added as parameters to transition in the animator.

 → **A)** isFinishedTalking is the param used for the Jim_scene_1 state transitions.


**8.** It is not perfect in its distilled form but it can be used to make whatever you want. 

**9.** Give credit where credit is due but if you obliterate the code and make something new all power to you of course.

**10.** Everything else is standard yarn functionality most of which is in the the current yarnspinner tutorial demo.

## I hope you enjoy making animated text adventures and that this inspires or helps you with your own project.
