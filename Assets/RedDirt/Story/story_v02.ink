VAR ending = 0

-> entrance

 ========= entrance =========
 
{stopping:
    - I'm in the parking lot on the end of my street, and I'm about to retrace my steps into the woods. I take a deep breath and then I’ll enter the path from where I left it. I am sure I will find what I am looking for there. #entrance00
    - I believe it is time to enter the path into the woods. #entrance01
}

* [forward]
    The cool shade of the trees licks the skin on my arms as I move in. #entrance02
    -> stream
+ [default]
    -> entrance

 ========= stream =========

{stopping:
    - I leave the streets behind me and slowly the sounds of the city fade away. The path winds down a trail with dry bushes on each side. The air gets warmer with each blink of my eyes. Maybe I should have left my winter jacket home? I don't need it here or where I'm going to. I can hear the stream getting closer, until I stop at its bank. #stream00 
    - There are no bridges around here, I'll have to ford the stream. #stream01
}

* [forward] 
    I want to go ahead, but the river is blocking the way.  #stream02
    -> stream
* [remember]
    I remember a sequence of steps and stumble my way across the river. When I last crossed here, I lost my sandals. I had to walk all the way home, barefoot over dirt, gravel and then summer-sun-hot asphalt. In the middle of the way, it rained, and I could feel the street cooling down under my feet. #stream03
    -> rock
+ [default]
    -> stream

 ========= rock =========
 
 {stopping:
    - As I continue walking the path, maybe in a different place now, the trees become larger. Some of them take root among large boulders of dark stone, covered in moss. I slowly press my fingertips along one of them, to feel its soft surface. I think I'm near the halfway point of the path by now. Yes, there it is, the Library Rock.  #rock00
    - Where is the library's book now? #rock01
}

* [forward]
    I can't bring myself to just continue ahaed. What if the book is still down there? #rock02
    -> rock
* [remember]
     I tap the sides of the boulder in front of me. I can see the markings in the moss. It is the library, definitely. I slowly wiggle it out of position, thinking of the times when keeping a book was an invitation to danger. #rock03
     -> rock
* [down]
    I move the rock to the side and reveal some dirt and gravel, wet and easy enough to dig with my hands. I find the book my father hid there many years ago, inside a plastic bag. I take it with me along the path, even though there are still people out there wanting to destroy it. #rock04
    -> hill
+ [default]
    -> rock


 ========= hill =========
 
 {stopping:
    - I continue walking. The trail gets a bit steeper. I can feel my legs aching slightly, making me recall other hills. Between the beaches of Ubatuba, the half-orange rolling mountains of Minas Gerais, the castle at the top of Morella town. I reach the top of the hill I'm walking now and I find a clearing. #hill00
    - Where to go now? #hill01
 }
 
 * [forward]
    Forward where? There is no opening at the edges of the clearing. There is no clear way forward. #hill02
    -> hill
* [remember]
    I take a couple deep breaths. The sun is high right now. I almost can't find my shadow. I miss this sensation of being pressed down by hot light, its dry feeling in the skin. #hill03
    -> hill
* [down]
    I sit down to rest, and then lie down. Maybe I should stay here longer. #hill04
    -> hill
    
* [stay]
    I nap. When I wake up, I walk around the corners of the clearing, its borders. After a while, I see what looks like a house far into the forest. The distance is not clear, but I know it. That is where I need to be. #hill05
    -> farm
+ [default]
    -> hill

 ========= farm =========

{ending == 4: -> gameover }
{ 
    - ending == 0 : 
        As I dart downhill through the woods, I notice the forest changing. It is more spaced out now, with less branches to stumble upon. The trees are shorter and with more gnarly, darker barks. The house is still far, but not for long. #farm00
    - ending == 1 : 
        I'm close now. #farm01
    - ending == 2 : 
        I take a deep breath. #farm02 
    - ending >= 2 : 
        Slowly now. #farm03
}

* [forward]
    ~ ending++ 
    I approach the farm house. The doors and windows are closed. The small garden to the side is dry, the orange trees are hanging on, but look a bit tired. The dirt on the ground feels different. #farm04
    -> farm
* [remember]
    ~ ending++
    This is my grandmother's place. Last time I saw it, I was just a kid, maybe a young adult. It looks smaller now. I walk around the building, no one's here. I find a spot on the ground that looks like what I'm searching for.  #farm05
    -> farm
* { ending > 1 } 
    [down]
    ~ ending++ 
    I walk with my eyes fixed on the ground. I can still recall every nook and cranny. Some rocks moved, I guess. I kneel by a red patch of dirt and start digging. I take small clumps of soil, grass roots sliding through my fingers.  #farm06
    -> farm
* { ending > 2 } 
    [stay]
    ~ ending++
    I take the small seed I've been carrying in my pocket and hold it in my hand. It will stay here. #farm07
    -> farm
+ [default]
    -> farm


=== gameover ===

I dig some more. The ground here is fertile, it has been tended before. It has been cared for. The sun is almost setting by now, and the red in the dirt is even stronger. Yes, the seed will heal. Satisfied, I backtrack my path home, in the darkening dusk.  #end00

-> END.