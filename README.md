# Note
The purpose of this fork is to build a DLL to interface with other projects using, for example, Python.NET.  I didn't want to write my own Python/C++/whatever implementation of the entire battle system.  Luckily, this very nice one already exists!

The build in this repo is targeted for .NET framework version 4.5.2, which is very obsolete.  But with a few modifications, we can use a recent .NET SDK (like .NET 8.0, which is the version I tested this with).

See [INSTALL.md](INSTALL.md) for detailed instructions.

Below is the original README text.

---

# Summary
A console, text-based simulator of the Pokemon
Generation 1 battle system. Using an exhaustive
representation of the game and an event-driven UI, 
you can battle your pokemon just like in Pokemon
generation 1 (Red, Blue, Yellow). Written in C#.

# Game Model
The game model is an exhaustive replica of the original game.
All pokemon, moves, stats, formulae, and battle mechanics
have been exactly replicated. The representation itself is
highly domain-driven, with a close correspondance between
in-game entities and C# classes.

### Pokemon
Pokemon are their own custom type. This includes all
core information carried around by the Pokemon:
stats, types, HP, level, experience, status, moves, name,
number, and nickname.  Supports methods which change status,
adjust HP, and gain Exp.

### Moves
Moves are implemented using a complex abstract inheritance
hierarchy. The most abstract class, Move, only defines 3 public
methods, the most common of which is ExecuteAndUpdate(), which
executes the move.
Each individual move is a concrete class inheriting from a
hierarchy of abstract classes. Shared state and functionality
are stored in the abstract base classes, so only the differences
between the moves are stored in the moves themselves: the implementation
of ExecuteAndUpdate(), which is unique to each move. All moves are
implemented except for moves which immediately end the battle
(e.g., Teleport, Whirlwind).

### Battles
Battles are a custom class which implement a state machine to
represent which state the battle is in (e.g., move selection,
first pokemon attacks, second pokemon attacks, etc.), along with
all appropriate state transitions. To simplify the implementation
and adhere to the SRP, Battle only deals with the battle state and
transitions. Move selection is delegated to BattleActor interfaces
(either the text-based player or opponent AI), and move execution
is delegated to the moves and Pokemon themselves.

Pokemon that are in battle are stored in a wrapper BattlePokemon
class.  This stores relevant battle-only information, such as 
stat stage modifiers, keeping track of bide and disable, keeping
track of multi-turn moves, flinching, light screen & reflect, etc.
BattlePokmeon is the go-to interface for Moves to execute their
various effects upon the pokemon.

Battles themselves consist of two Side instances, two BattleActor
instances, and a field that keeps track of the battle state within the
state machine.
The abstract Side class keeps track of the player's move selection,
the current Pokemon out in battle, the remaining team, and has an abstract
method IsDefeated() which callers may query to see if the game is over
because one side lost.
