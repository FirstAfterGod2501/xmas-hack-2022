import cv2 as cv
import numpy as np
import threading

class Screen():

    def __init__(self, width, height, bots):
        self.width = width
        self.height = height
        self.fps = 100
        self.bg = "feilds/img.png"
        self.screen = cv.resize(cv.imread(self.bg), (self.width, self.height))
        self.bots = bots

    def update_frame(self):
        self.screen = cv.resize(cv.imread(self.bg), (self.width, self.height))
        self.print_bots()

    def out_screen(self):
        while True:
            self.update_frame()
            cv.imshow("frame", cv.resize(self.screen, dsize=(0, 0), fx=10, fy=10))
            if cv.waitKey(self.fps) == 27:
                break

    def print_bots(self):
        for bot in self.bots:
            x, y = bot.pos
            self.screen[x, y] = np.asarray([0, 0, 255])

    def loop(self):
        threading.Thread(target = self.out_screen, args=()).start()