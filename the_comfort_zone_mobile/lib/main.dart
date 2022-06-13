import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:the_comfort_zone_mobile/pages/furniture_item/furniture_item_overview.dart';
import 'package:the_comfort_zone_mobile/pages/home_page/navigation_page.dart';
import 'package:the_comfort_zone_mobile/pages/user/login.dart';
import 'package:the_comfort_zone_mobile/pages/user/registration.dart';
import 'package:the_comfort_zone_mobile/providers/furniture_item_provider.dart';
import 'package:the_comfort_zone_mobile/providers/user_provider.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => FurnitureItemProvider()),
      ChangeNotifierProvider(create: (_) => UserProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
      ),
      debugShowCheckedModeBanner: true,
      home: LoginPage(),
      onGenerateRoute: (settings){
        if (settings.name == NavigationPage.routeName){
          return MaterialPageRoute(builder: (context) => const NavigationPage());
        }
        if (settings.name == RegistrationPage.routeName){
          return MaterialPageRoute(builder:(context) => const RegistrationPage());
        }
        if (settings.name == FurnitureItemOverviewPage.routeName){
          return MaterialPageRoute(builder: (context) => const FurnitureItemOverviewPage());
        }
      },
    );
  }
}

