import { StatusBar } from 'expo-status-bar';
import React, { useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import {useForm} from 'react-hook-form';
import axios from 'axios';

export default function App() {
  const {register, handleSubmit} = useForm();
  var loggedInAccount;
  const onSubmit = data => {
    console.log(data);
    //var jsonObj = JSON.stringify(data);
    axios.post('https://localhost:44392/API/authenticate', data)
    .then (res => 
      console.log(res),
    )
  }
  return (
    <View style={styles.container}>
    <form onSubmit={handleSubmit(onSubmit)}>
      <Text>Username: </Text>
      <input type="text" {...register("username")} />
      <Text>Password: </Text>
      <input type="password" {...register("password")} />
      <input type="submit" />
    </form>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
