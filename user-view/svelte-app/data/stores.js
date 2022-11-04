import { writable } from "svelte/store";

// Pattern sample: persistent store, backed by localStorage
/*
const storedValue = localStorage.getItem("testValue");
export const valueStore = writable(storedValue);
valueStore.subscribe(value => {
    localStorage.setItem("testValue", value || "defaultValue");
});
*/

// Needed for api.js
export const baseUrlUserSearch = "http://localhost:9001";
export const baseUrlUserSignup = "http://localhost:9002";
