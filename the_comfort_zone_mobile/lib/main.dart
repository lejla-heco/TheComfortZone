import 'package:flutter/material.dart';
import 'package:the_comfort_zone_mobile/pages/user/login.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
      ),
      debugShowCheckedModeBanner: true,
      home: const LoginPage(),
    );
  }
}

