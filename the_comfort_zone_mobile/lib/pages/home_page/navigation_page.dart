import 'package:flutter/material.dart';
import 'package:the_comfort_zone_mobile/pages/appointment/appointments_overview.dart';
import 'package:the_comfort_zone_mobile/pages/favourite/favourites_overview.dart';
import 'package:the_comfort_zone_mobile/pages/home_page/home_page.dart';
import 'package:the_comfort_zone_mobile/pages/order/orders_overview.dart';
import 'package:the_comfort_zone_mobile/pages/space/spaces_overview.dart';

class NavigationPage extends StatefulWidget {
  static const String routeName = "/navigation-page";
  const NavigationPage({Key? key}) : super(key: key);

  @override
  State<NavigationPage> createState() => _NavigationPageState();
}

class _NavigationPageState extends State<NavigationPage> {
  int index = 2;
  final screens = [
    const SpacesOverviewPage(),
    const FavouritesOverviewPage(),
    const HomePage(),
    const OrdersOverviewPage(),
    const AppointmentsOverviewPage()
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      bottomNavigationBar: NavigationBarTheme(
          data: NavigationBarThemeData(
              indicatorColor: Colors.brown[100],
              labelTextStyle: MaterialStateProperty.all(
                  const TextStyle(fontSize: 14, fontWeight: FontWeight.w500))),
          child: NavigationBar(
            selectedIndex: index,
            animationDuration: const Duration(seconds: 2),
            labelBehavior: NavigationDestinationLabelBehavior.onlyShowSelected,
            onDestinationSelected: (index) => {
              if (mounted) {setState(() => this.index = index)}
            },
            destinations: const [
              NavigationDestination(
                icon: Icon(Icons.store_outlined),
                label: 'Furniture',
                selectedIcon: Icon(Icons.store),
              ),
              NavigationDestination(
                icon: Icon(Icons.favorite_border),
                label: 'Favourites',
                selectedIcon: Icon(Icons.favorite),
              ),
              NavigationDestination(
                icon: Icon(Icons.home_outlined),
                label: 'Home',
                selectedIcon: Icon(Icons.home),
              ),
              NavigationDestination(
                icon: Icon(Icons.history_outlined),
                label: 'Orders',
                selectedIcon: Icon(Icons.history),
              ),
              NavigationDestination(
                icon: Icon(Icons.newspaper_outlined),
                label: 'Appointment',
                selectedIcon: Icon(Icons.newspaper),
              ),
            ],
          )),
      appBar: AppBar(
        iconTheme: const IconThemeData(color: Colors.black),
        title: const Text('The Comfort Zone',
            style: TextStyle(color: Colors.black)),
        backgroundColor: Colors.grey[100],
        centerTitle: true,
        elevation: 0.0,
      ),
      drawer: Drawer(
        child: ListView(
          children: [
            const DrawerHeader(
              decoration: BoxDecoration(
                  image: DecorationImage(
                image: AssetImage("assets/images/header-bg.jpg"),
                fit: BoxFit.fill,
              )),
              child: Center(
                child: Text(
                  "",
                ),
              ),
            ),
            ListTile(
              title: const Text('My Cart'),
              onTap: () {
                Navigator.of(context).pushNamed("/cart");
              },
            ),
            ListTile(
                title: const Text("My Profile"),
                onTap: () {
                  print("cart");
                }),
            ListTile(
                title: const Text("Logout"),
                onTap: () {
                  print("cart");
                }),
          ],
        ),
      ),
      body: screens[index],
      floatingActionButton: index == 1
          ? null
          : FloatingActionButton(
              onPressed: () {
                setState(() {
                  //TODO
                });
              },
              child: Icon(Icons.edit),
              tooltip: 'Create new consultation!',
              backgroundColor: Colors.black,
            ),
    );
  }
}
