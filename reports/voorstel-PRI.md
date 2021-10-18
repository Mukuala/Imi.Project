# Beschrijving

Ik zal een applicatie maken in verband met films. In de applicatie kan de user de filmen aanvinken die hij al heeft bekeken of wilt bekijken. Ook kan hij een review plaatsen en score achterlaten voor de flims die hij al heeft bekeken.
Er kan ook gezocht worden naar movies/actors/users a.d.h.v. hun naam.

# Rollen

Er zijn 2 soorten gebruikers: User , Admin (kan meer toevoegen)

Admin : kan users, movies, genres en actors toevoegen/verwijderen/aanpassen

User: kan eigen review aanpassen/verwijden/aanmaken (Extra)

# Api-Controllers

- Users, Genres, Actors, Movies, WatchLists, Favorites

# Api-Endpoints

Movies

- GET /api/movies
- GET /api/movies/id
- GET /api/movies/id/actors
- GET /api/movies/search
- POST /api/movies
- PUT /api/movies
- DELETE /api/movies/id

Actors

- GET /api/actors
- GET /api/actors/id
- GET /api/actors/id/movies
- GET /api/actors/search
- POST /api/actors
- PUT /api/actors
- DELETE /api/actors/id

Users

- GET /api/users
- GET /api/users/id
- GET /api/users/id/watchlists
- GET /api/users/id/favorites
- GET /api/users/search
- POST /api/users
- PUT /api/users
- DELETE /api/users/id

Genres

- GET /api/genres
- GET /api/genres/id
- GET /api/genres/id/movies
- POST /api/genres
- PUT /api/genres
- DELETE /api/genres/id

WatchLists

- POST /api/watchlist
- DELETE /api/watchlist/id

Favorites

- POST /api/favorites
- DELETE /api/favorites/id

# Externe API

Voor mijn vijfde vue pagina zal ik de api van IMDB gebruiken om de top 250 films op te lijsten in rang met paginering.
