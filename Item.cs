using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Item : MonoBehaviour
{
 
    public GameObject pickupEffect;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.points++;
            GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(effect, 5);
            Destroy(this.gameObject);
        }
    }
}

import pygame
import time
pygame.init()
'''creating the program window''
back = (200, 255, 255) ##background color
mw = pygame.display.set_mode((500, 500)) #main window
mw.fill(back)
clock = pygame.time.Clock()

class Area():
  def __init__(self, x=0, y=0, width=10, height=10, color=None):
      self.rect = pygame.Rect(x, y, width, height) 
      self.fill_color = color
  def color(self, new_color):
      self.fill_color = new_color
  def fill(self):
      pygame.draw.rect(mw, self.fill_color, self.rect)
  def outline(self, frame_color, thickness):  #outline of an existing rectangle
      pygame.draw.rect(mw, frame_color, self.rect, thickness)   
  def collidepoint(self, x, y):
      return self.rect.collidepoint(x, y)      
'''Class label'''
class Label(Area):
  def set_text(self, text, fsize=12, text_color=(0, 0, 0)):
      self.image = pygame.font.SysFont('verdana', fsize).render(text, True, text_color)
  def draw(self, shift_x=0, shift_y=0):
      self.fill()
      mw.blit(self.image, (self.rect.x + shift_x, self.rect.y + shift_y))

YELLOW=(255,255,0)
BLUE=(80,80,255)
card=[]
num_card=4
X=70
for i in range(num_card):
    new_card=Label(X,170,70,100,YELLOW)
    new_card.outline(BLUE,10)
    new_card.set_text('CLICK',26)
    card.append(new_card)
    X+= 100
    

while True:
    if wait == 0:
        wait=20
        click=randint(1,num_card)
        for i in range(num_card):
            cards[i].color((255,255,0))
            if (i+i)==click:
                cards(i).draw(10,40)
            else:
                cards[i].fill()
    else:
        wait-=1

    for unecard in card:
        unecard.draw(10,30) 
    pygame.display.update()
    clock.tick(40)

