<template>
  <div id="app">
    <keep-alive>
      <router-view />
    </keep-alive>
  </div>
</template>

<style>
:root {
  box-sizing: border-box;
  font-size: calc(1vw + 0.9em);
}
@media (min-width: 35em) {
}
@media (min-width: 50em) {
  :root {
    font-size: 1.25em;
  }
}
/* *,
*::before,
*::after {
  box-sizing: inherit;
} */
*{
    margin: 0;
    padding: 0;
}
html, body
{
  position: absolute !important;
  width: 100%;
  height: 100%;
  user-select: none;
}
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
header {
  height: 2rem;
  line-height: 2em;
  text-align: center;
  background-color: rgb(175, 245, 245);
}
.content{
  width: 100%;
  height: calc(100vh - 2rem);
}
.left, .right{
  position: absolute;
  font-size: 1.5rem; 
}
.left{
  left: 0.5em;
}
.right{
  right: 0.5em;
}
</style>
