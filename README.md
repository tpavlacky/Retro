![Build](https://github.com/tpavlacky/Retro/workflows/Build/badge.svg) 

# General
This awesome and high-end application will allow you to store your remarks to the next retrospective.

# How to

* add -> Records retro point
  * -n, --Negative -> (**Required**) Positive experience
  * -p, --Positive  -> (**Required**) Negative experience
  * -k, --Kudos  -> (**Required**) Kudos
  * -t, --To  -> (**Optional**) Kudos to who? 
  * --help  -> Display this help screen.
  * --version  -> Display version information.

* dump -> Writes recorded retro points
* clear -> Removes all recorded retro points
* help -> Display more information on a specific command.
* version -> Display version information.

# Examples
## Add new negative experience
### Command
retro add -n "Negative experience :("
### Result
```bash
================== Retro points ==================
Positive points:

Negative points:
21.01.2021 15:25 -> Negative experience :(

Kudos:
```

## Add new positive  experience
### Command
retro add -p "Positive experience :)"
### Result
```bash
================== Retro points ==================
Positive points:
21.01.2021 15:26 -> Positive experience :)

Negative points:

Kudos:
```

## Add new kudos
### Command
* retro add -k "TP -> Very good job during sprint"
### Result
```bash
================== Retro points ==================
Positive points:

Negative points:

Kudos:
21.01.2021 15:27 -> TP -> Very good job during sprint
```

### Command
* retro add -k -t "TP" "Very good job during sprint"
### Result
```bash
================== Retro points ==================
Positive points:

Negative points:

Kudos:
21.01.2021 15:27 -> 'TP' -> 'Very good job during sprint'
```
