from pygame import *
class GameSprite(sprite.Sprite):
   def __init__(self, player_image, player_x, player_y, size_x, size_y):
       sprite.Sprite.__init__(self)
       self.image = transform.scale(image.load(player_image), (size_x, size_y))
       self.rect = self.image.get_rect()
       self.rect.x = player_x
       self.rect.y = player_y
   def reset(self):
       window.blit(self.image, (self.rect.x, self.rect.y))

class Player(GameSprite):
   def __init__(self, player_image, player_x, player_y, size_x, size_y, player_x_speed, player_y_speed):
       GameSprite.__init__(self, player_image, player_x, player_y, size_x, size_y)
       self.x_speed = player_x_speed
       self.y_speed = player_y_speed
   def update(self):
       self.rect.x += self.x_speed
       self.rect.y += self.y_speed

largeur_fenetre = 700
hauteur_fenetre = 500
display.set_caption("Labyrinthe")
window = display.set_mode((largeur_fenetre, hauteur_fenetre))
arriere_plan = (119, 210, 223)
m1 = GameSprite('platform2.png', largeur_fenetre / 2 - largeur_fenetre / 3, hauteur_fenetre / 2, 300, 50)
m2 = GameSprite('platform2_v.png', 370, 100, 50, 400)
packman = Player('hero.png', 5, hauteur_fenetre - 80, 80, 80, 0, 0)

run = True
while run:
    time.delay(50)
    window.fill(arriere_plan)
  
    for e in event.get():
        if e.type == QUIT:
            run = False
        elif e.type == KEYDOWN:
            if e.key == K_LEFT:
                packman.x_speed = -5
            elif e.key == K_RIGHT:
                packman.x_speed = 5
            elif e.key == K_UP:
                packman.y_speed = -5
            elif e.key == K_DOWN:
                packman.y_speed = 5
        elif e.type == KEYUP:
            if e.key == K_LEFT:
                packman.x_speed = 0
            elif e.key == K_RIGHT:
                packman.x_speed = 0
            elif e.key == K_UP:
                packman.y_speed = 0
            elif e.key == K_DOWN:
                packman.y_speed = 0

   packman.reset()
   packman.update()
   display.update()
