# Khayrullo Isomiddinov
# BET9FI

* The task:  It is about the hydrological cycle of the earth and how various types of areas are affected by various types of weather.
Some points about the task requirements: 

1. We assume the weather is sunny if the humidity level is below 40.
2. If humidity level (%) is between 40 (inclusive) and 70, the chance of rain is 50-50.
3. If 70% or higher, the weather is considered rainy.

Whenever the weather is rainy, the humidity level for the next round drops to 30 percent. After all the areas are checked and if they
affect the humidity levels, we take the increase from that type of area and add it to the original 30. This sets the humidity level for 
the next round. 

# sample input:
4 
Mr Bean L 86 
Mr Green G 26 
Mr Dean P 12 
Mr Teen G 35 
98

# sample output (iteration 1)
Mr Bean L 106
Mr Green G 41
Mr Deann G 32
Mr Teen G 50
60

...

Since the weather was rainy, the amount of water for the lake regions is increasing by 20. By 20 for the Plain, and 15 for the grass.
Since Lake in the rainy weather increases the humidity by 15% and Grass by 10% and Plain by 5%, 15 + 10 + 5 = 30. 30 + 30 (the original
level of humidity that decreased due to rain) = 60.
