import random
import time
from math import sqrt

class MoveLogic:

    def __init__(self, bots):
        self.bots = bots
        self.point = (0, 0)

    def set_point(self, point):
        self.point = point

    def calculat_distance(self, point1, point2):
        return sqrt((point1[0]-point2[0])**2+(point1[1]-point2[1])**2)

    def is_occupied_point(self, point, bots, it):
        for bot in bots:
            if bot.pos == point and bot != it:
                return True
        return False

    def find_best_angle(self, bot, point):
        position = bot.pos
        spead = bot.spead
        best_distance = float("inf")
        best_angle = (0, 0)
        for x in range(-1, 2):
            for y in range(-1, 2):
                temp_position = (position[0]+x*spead, position[1]+y*spead)
                temp_distance = self.calculat_distance(temp_position, point)
                if temp_distance < best_distance and not self.is_occupied_point(temp_position, self.bots, bot):
                    best_distance = temp_distance
                    best_angle = (x, y)
        return best_angle

    def rand_move(self, bot):
        bot.angle = (random.randint(-1, 1), random.randint(-1, 1))
        temp_position = (bot.pos[0] + bot.angle[0] * bot.spead, bot.pos[1] + bot.angle[1] * bot.spead)
        if self.is_occupied_point(temp_position, self.bots, bot):
            bot.angle = (0, 0)
            return
        bot.move()


    def move_master(self):
        bot = self.bots[0]
        bot.angle = self.find_best_angle(bot, self.point)
        bot.move()

    def move_slaves(self):
        master_pos = self.bots[0].pos
        for bot in self.bots[1:]:
            if self.calculat_distance(master_pos, bot.pos) < bot.communication_range - bot.communication_nice:
                self.rand_move(bot)
            else:
                bot.angle = self.find_best_angle(bot, master_pos)
                bot.move()


    def swarm(self):
        while self.bots[0].pos != self.point:
            self.move_master()
            self.move_slaves()
            time.sleep(0.05)

        for i in range(10):
            self.move_slaves()
            time.sleep(0.05)