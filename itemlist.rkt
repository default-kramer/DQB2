#lang racket

(define dye? (or/c #f 'white 'pink 'red 'yellow 'green 'blue 'purple 'black))

(define/contract (I id name dye)
  (-> integer? string? dye? any/c)
  (list id name dye))

(define-syntax-rule (make-item-list [id name dye] ...)
  (list (I id name dye)
        ...))

(define itemlist
  (make-item-list
   [1 "Bottomless Pot" #f] ; pot content (eg Seawater) probably matches whatever the tool has?
   [2 "Medicinal Herb" #f]
   [3 "Slimespawn" #f]
   [4 "Transform-O-Trowel" #f]
   [5 "Cactus Seed" #f]
   [6 "Antidotal Herb" #f]
   [7 "Anvil" #f]
   [8 "Citadel Bracket" #f]
   [9 "Corrupted Cactus" #f]
   [10 "Patterned Citadel Wall" #f]
   [11 "Corrupted Cactus" #f]
   [12 "Wooden Grating" 'white]
   [13 "Seed of Life" #f]
   [14 "Wooden Grating" 'black]
   [15 "Wooden Grating" 'purple]
   [16 "Defuddle Drops" #f]
   [17 "Tingle Tablet" #f]
   [18 "Wooden Grating" 'pink]
   [19 "Wooden Grating" 'red]
   [20 "Planted Earth" #f]
   [21 "Wooden Grating" 'green]
   [22 "Wooden Grating" 'yellow]
   [23 "Wooden Grating" 'blue]
   [24 "Poled and Planted Earth" #f]
   [25 "Ladder" 'white]
   [26 "Ladder" 'black]
   [27 "Ladder" 'purple]
   [28 "Ladder" 'pink]
   [29 "Mountaintop Temple" #f] ; blueprint
   [30 "Small Window" 'white]
   [31 "Bottomless Pot" #f] ; empty?
   [32 "Fishing Rod" #f]
   [33 "Beacon of Erdrick" #f]
   [34 "" #f] ; black block?
   [35 "Key" #f]
   [36 "Rubber Ring" 'white]
   [37 "Spaceship Corner Capital" #f]
   [38 "Spaceship Corner Midsection" #f]
   [39 "Spaceship Corner Foundation" #f]
   [40 "Spaceship Capital" #f]
   [41 "Reinforced Iron Corner" #f]
   [42 "Comfy Sofa" 'white]
   [43 "Comfy Sofa" 'black]
   [44 "Springtide Sprinkles" #f]
   [45 "Connecting Tiling" 'white]
   [46 "Comfy Sofa" 'purple]
   [47 "Yggdrasil Leaf" #f]
   [48 "Ladder" 'red]
   [49 "Comfy Sofa" 'pink]
   [50 "Spaceship Foundation" #f]
   [51 "Comfy Sofa" 'red]
   [52 "Builder's Workbench" #f]
   [53 "Comfy Sofa" 'green]
   [54 "Ladder" 'green]
   [55 "Ladder" 'yellow]
   [56 "Pyramid Pinnacle" #f] ; blueprint
   [57 "Ladder" 'blue]
   [58 "Silver Birch Seed" #f]
   [59 "Pyramid Pinnacle" #f] ; blueprint
   [60 "Comfy Sofa" 'yellow]
   [61 "Minecart Station" #f] ; blueprint
   [62 "Confusing Claw" #f]
   [63 "Comfy Sofa" 'blue]
   [64 "Flute Fragment" #f]
   [65 "" #f] ; black block?
   [66 "Connecting Tiling" 'black]
   [67 "Citadel Corner" #f]
   [68 "Flute Fragment" #f]
   [69 "Citadel Window" #f]
   ; 85 - 94 look similar to Weather Cards but have no name
   [95 "Spaceship Wall" 'white]
   [96 "Spaceship Wall" 'black]
   [97 "Spaceship Wall" 'purple]
   [98 "Spaceship Wall" 'pink]
   [99 "Spaceship Wall" 'red]
   [101 "Acorn" #f]
   [102 "Enchanted Ember" #f]
   [103 "Pipe" #f]
   [104 "Vertical Pipe" #f]
   [105 "Bent Pipe" #f]
   [106 "Left-to-Bottom Bent Pipe" #f]
   [107 "Left-to-Top Bent Pipe" #f]
   [108 "Right-to-Top Bent Pipe" #f]
   [109 "Upward Joint Pipe" #f]
   [110 "Flame-Grilled Plumberry" #f]
   [111 "Shrooms-on-a-Stick" #f]
   [112 "Cactus Steak" #f]
   [113 "Pot Plant" 'white]
   [114 "Downward Joint Pipe" #f]
   [115 "Cross Pipe" #f]
   [116 "Borrowed Hammer" #f]
   [117 "Borrowed Hammer" #f] ; looks like War Hammer?
   [118 "Borrowed Hammer" #f] ; looks like Ultimallet?
   [119 "Snow Cone" #f]
   [120 "Pot Plant" 'black]
   [121 "Storage Bay" #f]
   [122 "Bouillabaisse" #f]
   [123 "Boiled Butterbeans" #f]
   [124 "Mason's Workstation" #f]
   [125 "Pot Plant" 'purple]
   [126 "Spaceship Corner" #f]
   [127 "Bread" #f]
   [128 "Spaceship Wall" 'green]
   [129 "Pot Plant" 'pink]
   [130 "Spaceship Wall" 'yellow]
   [131 "Burger" #f]
   [132 "Potato Salad" #f]
   [133 "Spaceship Wall" 'blue]
   [134 "Shiny Spaceship Wall" 'white]
   [135 "Pot Plant" 'red]
   [136 "Shiny Spaceship Wall" 'black]
   [137 "Shiny Spaceship Wall" 'purple]
   [138 "Searing Steak" #f]
   [139 "Coddled Egg" #f]
   [140 "Fried Egg" #f]
   [141 "Pot Plant" 'green]
   [142 "Ice Cream" #f]
   [143 "Rubber Ring" 'black]
   [144 "Shiny Spaceship Wall" 'pink]
   [145 "Pot Plant" 'yellow]
   [146 "Pot Plant" 'blue]
   [147 "Small-Scale Soldier" 'white]
   [148 "Small-Scale Soldier" 'black]
   [149 "Small-Scale Soldier" 'purple]
   [150 "Wheat" #f]
   [151 "Sugar Cane" #f]
   [152 "" #f] ; black block?
   [153 "Planted Earth" #f]
   [154 "Planted Humus" #f]
   [155 "Mud-Brick Wall Rubble" #f]
   [156 "Sheen Salts" #f]
   [157 "" #f] ; black block?
   [158 "" #f] ; black block?
   [159 "Tingleweed Seed" #f]
   [160 "Small Window" 'black]
   [161 "Small Window" 'purple]
   [162 "Connecting Tiling" 'purple]
   [163 "Grass Seed" #f]
   [164 "Connecting Tiling" 'pink]
   [165 "Connecting Tiling" 'red]
   [166 "Connecting Tiling" 'green]
   [167 "Connecting Tiling" 'yellow]
   [168 "Small-Scale Soldier" 'pink]
   [169 "Small-Scale Soldier" 'red]
   [170 "Shiny Spaceship Wall" 'red]
   [171 "Sailor's Stew" #f]
   [172 "Porridge" #f]
   [173 "Shiny Spaceship Wall" 'green]
   [174 "Cream of Marshroom Soup" #f]
   [175 "Fries" #f]
   [176 "Fresh Fish Feast" #f]
   [177 "Squid-on-a-Stick" #f]
   [178 "Cooked Crab Claw" #f]
   [179 "Shiny Spaceship Wall" 'yellow]
   [180 "Buttermilk" #f]
   [181 "Shiny Spaceship Wall" 'blue]
   [183 "Medicinal Herb" #f] ; black block?
   [187 "Small-Scale Soldier" 'green]
   [188 "Small-Scale Soldier" 'yellow]
   [189 "Small-Scale Soldier" 'blue]
   [190 "Biblio-Pile" 'white]
   [191 "Biblio-Pile" 'black]
   [192 "Biblio-Pile" 'purple]
   [193 "Biblio-Pile" 'pink]
   [194 "Biblio-Pile" 'red]
   [195 "Biblio-Pile" 'green]
   [196 "Biblio-Pile" 'yellow]
   [197 "Biblio-Pile" 'blue]
   [198 "Strong Medicine" #f]
   [199 "Markedly Medicinal Leaf" #f]
   [200 "" #f] ; medicinal herb?
   [201 "Wheatgrass Seed" #f]
   [202 "Historic Hammer" #f]
   [203 "Connecting Tiling" #f]
   [204 "Ridged Wooden Roofing" #f]
   [205 "Black Coffee" #f]
   [206 "Fruity Tart" #f]
   [207 "Frogstool" #f]
   [208 "Counter" #f]
   [209 "Crabby Croquette" #f]
   [210 "Nameplate" 'blue]
   [211 "Spaceship Wall" #f]
   [212 "Shiny Spaceship Wall" #f]
   [213 "Salmon Rice Ball" #f]
   [214 "Chicken Drumsticks" #f]
   [215 "Leaf of Life" #f]
   [216 "Spaceship Corner" 'white]
   [217 "Spaceship Corner" 'black]
   [218 "Spaceship Corner" 'purple]
   [219 "Spaceship Corner" 'pink]
   [220 "Wooden Fencing" #f]
   [221 "Connecting Tiling" 'blue]
   [222 "Spaceship Corner" 'red]
   [223 "Light Bulb" #f]
   [224 "Pub Sign" #f]
   [225 "Basic Bathtub" #f]
   [226 "Patterned Vault Wall" #f]
   [227 "Curtain" #f]
   [228 "Postbox" #f]
   [229 "Sandstone Brick" #f]
   [230 "Small Window" 'pink]
   [231 "Fan Fern" #f]
   [232 "Gladiolus" #f]
   [233 "Broken Track" #f]
   [234 "Spider Web" #f]
   ))

itemlist