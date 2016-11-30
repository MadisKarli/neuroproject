# neuroproject

Data logging instructions:

Keep an eye on unity console, make sure that "Collapse" option isn't chosen.

Tables are named L(left), R(right), C(center), as positioned when standing by the door and facing the experiment area. 

0.To reset the scene press SPACE.
0.5 Make sure gravity is enabled. To toggle gravity press G. There will be a notification in the console if it was enabled/disabled.
1.To start a new experiment, press N.
2.To start the timer for a table, press the corresponding key(L for left and so on...)
2.5 To cancel the timer press Q
3.To stop the timer, hold down the corresponding key for that table. When the countdown reaches 0 the time at the start of countdown will be logged, if the key is released earlier (e.g. if the tower falls over before the countdown) the time wont be logged and the timer will continue. The confirmation time can be set from the "Logger" gameobject under Logger script. (NB! Only one timer can be active at any moment)
4.To end the experiment, press N.

The times are written to Assets/data/log.txt
