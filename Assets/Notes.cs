/*
This is an entirely bullshit file just for notes


# Map Object Design
Size: (x, y)
Start Position: (x, y), (x, y)    // for two players
Walls: ((x, y), (x, y) ... (x, y)), ((x, y), (x, y) ... (x, y)), etc      // sequence of connected wall points, multiple if needed
Continous spawn: 0 or 1    // discrete rounds or non-stop spawning
Zombie Entrances: ((x, y, 0 or 1))    // boolean if horizontal or vertical (angled?) // what if they want bigger? idk could be set of line points...
Perk Machines: (x, y, perkID)
Pack: (x, y)
Box Locations: (x, y, 0 or 1), (x, y, 0 or 1) ...     // boolean for where box is
Win Location(s): (x, y, # points to win)
Soul Chests: 
Gun Locations: (x, y, gunID, color, # of points)

Power up spawn locations?    // arrows pointing toward spawned pwoer ups


# Perk IDs
| Name | ID | Function | Cost | Perma |
| ---- | -- | -------- | ---- | ----- |
| Jug | 0 | Two more bars of health | 4000 | 10000 |
| Mags | 1 | Extra Mag Capacity | 3000 | 8000 |
| Speed | 2 | Speed Reload, Movement | 3000 | 8000 |
| Fix | 3 | Repairs One barrier | 3000 | 8000 |


# Gun IDs
| Name | ID | Bullet Type | Mag Size | Reload Time | Mobility | Fire Rate | Bullet Damage | Effects |
| ---- | -- | ----------- | -------- | ----------- | -------- | --------- | ------------- | ------- |
| Pistol | 0 | Light | Low | Fast | High | Low | Medium |
| SMG | 1 | Light | Medium | Medium | High | High | Low |
| AR | 2 | Heavy | Medium | Medium | Medium | Medium | Medium | 
| LMG | 3 | Heavy | Large | Slow | Low | Medium | Medium |
| Sniper | 4 | Heavy | Low | Medium | Medium | Slow | High (penetrative) |
| Shotty | 5 | Light | Low | Medium | Medium | Medium | Medium |
| Zap | 6 | Energy | Medium | Slow | High | Medium | Medium (splash) | Drops zombies speed?
| Blast | 7 | Energy | Medium | High | High | Low | Low |
| Rocket | 8 | Energy | Low | Low | Low | Low | High (massive spash) |
| Wonder | 9 | ??? | Medium | Medium | Medium | Medium | High |


# Box Ratios
White: 20%
Green: 20%, Upgrade 3000
Blue: 15%, Upgrade 5000
Purple: 15%, Upgrade 7000
Gold: 10%, Upgrade 10000

# Power ups
| Name | ID | Effect |
| ---- | -- | ------ |
| Ammo | 0 | Replenish ammo |
| Nuke | 1 | Removes all zombies in a given radius, giving points for kills |
| Time | 2 | Slows all zombies speed to a crawl |
| Infinite | 3 | Gives players infinite ammo |
| Upgrade | 4 | Free gun upgrade |
| Health | 5 | Makes everyone invinsible |



# Game Controller
- Spawns rogues based up to certain level amount and limited number spawned
- checks continous vs discrete spawn conditions

# Player Controller
- Check health
- Is near perk to buy

# Rogue Controller
- check health
- move toward player

// Sprint 1
- zombies chase
- 

// Sprint 2
- touch controls on ios
- rounds

// Sprint 3
- play/pause
- perks
- win condition

// Sprint 4
- guns
    - upgrades
- power ups
- main menu

 */