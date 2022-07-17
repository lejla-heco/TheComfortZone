The Comfort Zone - R2 seminarski rad
=====================================

TheComfortZone je aplikacija koja služi za pregled ponude salona namještaja, pruža mogućnost naručivanja, lajkanja (premještanja u sekciju favourites), pregleda historije narudžbi, te pruža i mogućnost zakazivanja i pregleda historije dizajn konsultacija + obuhvata administracijski dio samog poslovnog procesa kao cjeline:

Desktop aplikacija je namijenjena administratorima i zaposlenicima za obavljanje administracijskog i poslovnog dijela procesa
mobilna aplikacija je namijenjena krajnjim korisnicima

Kredencijali za prijavu
Desktop aplikacija

    Administrator

    Korisnicko ime: admin             
    Lozinka: admin!password                                      

    Employee

    Korisnicko ime: employee1
    Lozinka: employee1     

    Korisnicko ime: employee2
    Lozinka: employee2

    Korisnicko ime: employee3
    Lozinka: employee3         

Mobilna aplikacija

    User

    Korisnicko ime: user                        
    Lozinka: user!password     

    Korisnicko ime: user2
    Lozinka: user!password   

Pokretanje aplikacija

Nakon kloniranja repozitorija sa lokacije: https://github.com/lejla-heco/TheComfortZone.git navigirati kroz komandnu liniju do istog, te pokrenuti dokerizovani API i TheComfortZone DB upotrebom sljedećih naredbi (za seeding se koristi skripta setup.sql):

    docker-compose build
    docker-compose up

Nakon otvaranja mobilnog dijela aplikacije the_comfort_zone_mobile dohvatiti dependencyije:

    flutter pub get

Te pokrenuti aplikaciju:

    flutter run

Pokretanje desktop aplikacije se vrši unutar Visual Studia
