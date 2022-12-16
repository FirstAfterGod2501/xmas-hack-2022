import time

from screen import Screen
from drone import Drone
from move_logic import MoveLogic

bots = []
for i in range(15):
    bots.append(Drone((1, i)))


point = (45,76)

screen = Screen(100, 100, bots)
screen.loop()

time.sleep(1)
move = MoveLogic(bots)
move.set_point(point)
move.swarm()































