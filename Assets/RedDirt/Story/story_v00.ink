VAR learned = 0
VAR dig = 0

-> intro

== intro

I will retrace my steps now. I will take a deep breath and remember where I left the path I was following then. I am sure I will find what I am looking for there. # intro00

-> learn_signs

== wood_start

{cycle:
    - The trees are kind of dry around here. # start01
    - There are leaves in the ground. # start02
    - I do not recognize any rocks here. # start03
}

+ [forward]
    I step a bit deeper into the path. The ground is moist, sticky and cold. # start04
    -> wood_start
+ [look]
    Looking around, I notice a few broken twigs and a small trail into the bushes. # start06
    -> first_hall
+ [other]
    I just got back into the path. I am not leaving right now. # start05
    -> wood_start


== learn_signs

{learned == 0: 
    The traces I left around the path will help me find my way. Every once in a while, I will need to re-trace them. I might outline them in the ground, in the bark of a tree, in the palm of my hand. # learn01
    ~ learned = 1
}

+ [forward]
    The cool shade of the trees licks the skin in my arms as I move in. # learn02
    -> wood_start
+ [other]
    I need to take a step forward to enter the path. # learn03
    -> learn_signs


== first_hall

{cycle:
    - I take a few steps in. There is not a lot to see, it is dense. I try to remember how it felt to come here from the other end. I cannot really recall. # hall01
    - I look down every once in a while, but I do not find what I am looking for. # hall02
    - I have the impression it is getting a bit warmer here. # hall03
}

+ [forward]
    Branches cling to my clothes. Stepping forward feels a bit slow somehow? #hall04
    -> first_hall
+ [look]
    I scratch at the rocks and lumps of soil near my feet. No success so far. #hall05
    -> second_hall
+ [other]
    Breath-in, breath-out. I've been through this before. #hall06
    -> first_hall


=== second_hall

{dig == 0:
    I see a tree stump, one that I have seen before. # second01
    ~ dig++
}

{dig > 3:
    -> end_game
}

{cycle:
    - It was not like this when I passed by back then. # second02
    - I can recognize this land. I stick and drag my nails on its top layer. # second03
    - I am almost there. I can smell it. # second04
    - It is so close now. # second10
}

+ [forward]
    I continue ahead, crawling on my knees. # second05
    -> second_hall
+ [look]
    {cycle:
        - I lift some rocks, the gravel looks familiar. # second07
        - So many things have taken place here. They have come and gone. # second08
        - I sense the coming together of water, ground and root. # second09
    }
    ~ dig++
    -> second_hall
+ [other]
    I will not turn back. # second06
    -> second_hall


=== end_game

I stop near a clearing. It feels huge and airy: I can see clouds through the tree canopies. I dig a clump of red dirt with my left hand as I hold on to a small seed in the other. (small pause) I dig some more, the dirt has just the right red hue here. Yes, it will grow and heal. I am satisfied.  # end01

-> END










