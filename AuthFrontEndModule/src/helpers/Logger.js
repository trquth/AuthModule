const isDevelopment = process.env.NODE_ENV === 'development'
class Logger {
	static log(){
		if (isDevelopment)
		console.log.apply(console, arguments)
	}
	static warn(){
		if (isDevelopment)
		console.warn.apply(console, arguments)
		for (let item of arguments){
			if (item instanceof Error){
				console.log(item.stack)
			}
		}
	}
	static error(){
		if (isDevelopment)
		console.error.apply(console, arguments)
		for (let item of arguments){
			if (item instanceof Error){
				console.log(item.stack)
			}
		}
	}
	static info(){
		console.info.apply(console, arguments)
	}
}

if (window) window.Logger = Logger;
export default Logger;