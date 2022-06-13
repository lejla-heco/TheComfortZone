import 'package:flutter/material.dart';

Widget TextInputWidget({required String label, required TextEditingController controller}) {
  const mandatoryField = "field cannot be left blank!";

  return TextFormField(
    validator: (value) {
      return value == null || value.isEmpty
          ? label + " " + mandatoryField
          : null;
    },
    controller: controller,
    decoration: InputDecoration(
        labelText: label,
        labelStyle: const TextStyle(fontSize: 16, color: Colors.white),
        enabledBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10),
            borderSide: BorderSide(color: Colors.grey.shade300)),
        focusedBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(10),
          borderSide: const BorderSide(color: Color.fromARGB(255, 114, 75, 50)),
        )),
  );
}
