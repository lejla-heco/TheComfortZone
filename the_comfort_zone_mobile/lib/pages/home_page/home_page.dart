import 'package:flutter/material.dart';

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Container(
            height: MediaQuery.of(context).size.height,
            width: MediaQuery.of(context).size.width,
            decoration: const BoxDecoration(
                image: DecorationImage(
              image: AssetImage("assets/images/home-page.jpg"),
              fit: BoxFit.fill,
            )),
            child: Center(
                child: Container(
              padding: const EdgeInsets.only(top: 100),
              child: Column(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: const [
                    Text("Discover new",
                        style: TextStyle(
                            fontSize: 35, fontWeight: FontWeight.bold)),
                    Text("relaxing furniture",
                        style: TextStyle(
                            fontSize: 33, fontStyle: FontStyle.italic))
                  ]),
            ))));
  }
}
