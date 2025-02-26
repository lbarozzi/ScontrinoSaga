window.printSvg = function () {
    // Salva il contenuto attuale della pagina
    const originalContent = document.body.innerHTML;
    
    // Ottieni l'SVG da stampare
    const svgElement = document.getElementById('printableSvg');
    
    // Imposta il contenuto della pagina solo all'SVG
    document.body.innerHTML = `
        <style>
            @media print {
                body { margin: 0; padding: 0; }
                svg { width: 100%; height: auto; }
            }
        </style>
        ${svgElement.outerHTML}
    `;
    
    // Esegui la stampa
    window.print();
    
    // Ripristina il contenuto originale
    document.body.innerHTML = originalContent;
    
    // Riattivare Blazor dopo il ripristino (necessario per i gestori di eventi)
    Blazor.reconnect();
};