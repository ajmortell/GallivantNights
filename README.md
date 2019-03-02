# GallivantNights
A cyber-horror thriller. An homage to games like Snatcher and Super Spy-hunter.

We have added a small tech demo that allows you to use yarn to make animated panels along with your text/options.

# To use simply..
1.  Open the file in Assets/Scenes called DialogueScene
2. Once in unity navigate to the folder structure and look in Assets/Prefabs/Animations/Scenes/...
  A) this is where the animated panels we have set up are located.
  B) note they have an animated entity script attached that says what color their label is and what type and initial state they are in
  C) These panels are loaded through the .yarn file via commands ([YarnCommand("MyCommand")]]
  D) You can make any sized panel you chose these are the sizes we find fits our model best.
3. Next load up yarn and find the scene_0.yarn file in the Assets/Yarnspinner/Dialogues folder and see how the commands are used
4. Next we have the DialogueManager (Assets/Scripts/Dialogue) where most of the commands are located.
5. Note how everything is hooked up to the Dialogue object in the hierarchy.
6. Don't forget that each NPC scenes needs to be noted in the AnimatedEntity script in the inspector.
  A) This can be changed in code but it needs and initial setting.
7. Also remember that each NPC has states that must be added as parameters to transition in the animator.
  A) isFinishedTalking is the param used for the Jim_scene_1 state transitions.
8. It is not perfect in its distilled form but it can be used to make whatever you want. 
9. Give credit where credit is due but if you obliterate the code and make something new all power to you of course.
  A) this serves our purposes perfectly and we are now moving on to the second have of the gameplay.
10. Everything else is standard yarn functionality most of which is in the the current yarnspinner tutorial demo.

# I hope you enjoy making animated text adventures and we hope this inspires or helps you with your own project.
