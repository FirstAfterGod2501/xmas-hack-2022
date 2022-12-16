import random

class Drone:

    def __init__(self, pos):
        self.pos = pos
        self.angle = (0, 0)
        self.spead = 1
        self.communication_range = 10
        self.communication_nice = 10

    def move(self):
        self.pos = (self.pos[0] + self.angle[0]*self.spead, self.pos[1] + self.angle[1]*self.spead)











