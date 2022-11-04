
<script lang="ts">
	import Button, { Label } from '@smui/button';
	import Textfield from '@smui/textfield';
   	import {API} from '../data/api';
	import  type User from '../data/model';

	let users: User[] = [];
	let api = new API();
	let kw = '';
	let page = 0;
	let size = 10;

	$: if (kw){
		console.log('You entered ' + kw);
	} else {
		console.log('Please enter a keyword');
	}

	async function searchUsers ()  {
		console.log("Fetching weathers via API.");
		let sanitized = kw.replace(/[^\w|\s]/gm, '').replace(/\s{2,}/gm, ' ');
		users = await api.userSearchGet(`/users?kw=${sanitized}&page=${page}&size=${size}`);
		console.debug('userSearchGet returned ', users);
	}

	async function searchFirst ()  {
		page = 0;
		await searchUsers();
	}

	async function searchNext ()  {
		page++;
		searchUsers();
	}

  </script>

<main style="display: flex; flex-direction: column;">
	<div style="display: flex; align-items: self-end; margin: 0 auto;">
		<div style="margin-right: 10px;">
			<Textfield label="User Name" bind:value={kw}/>
		</div>
		
		<div style="margin-right: 10px;">
			<Button variant="outlined" on:click={searchFirst}>
				<Label>Search</Label>
			</Button>
		</div>
	</div>

	<h1>User List</h1>
	<div style="display: flex; align-items: self-end; margin: 0 auto;">
		{#if users && users.length}
			<div style="margin-right: 10px;">
				<ul>
					{#each users as w (w.id)}
						<li>{`${w.id} - ${w.userName} - ${w.fullName}`}</li>
					{/each}
				</ul>
			</div>
		{:else}
			<p>Not found</p>
		{/if}
	</div>
	<div style="margin-top: 10px;">
		<div style="margin-right: 10px;">
			Page: {page}
		</div>
		<Button variant="outlined" on:click={searchNext}>
			<Label>Next Page</Label>
		</Button>
	</div>
</main>


<style>
	main {
		text-align: center;
		padding: 1em;
		max-width: 240px;
		margin: 0 auto;
	}

	h1 {
		color: #ff3e00;
		font-size: 2em;
		font-weight: 100;
	}

	@media (min-width: 640px) {
		main {
			max-width: none;
		}
	}
</style>



